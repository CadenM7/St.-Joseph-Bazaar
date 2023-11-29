using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StJosephBazaar.Data;
using StJosephBazaar.Models;

namespace StJosephBazaar.Pages.Incomes
{
    public class IndexModel : PageModel
    {
        private readonly StJosephBazaar.Data.BazaarContext _context;

        private readonly IConfiguration Configuration;

        public IndexModel(StJosephBazaar.Data.BazaarContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }


        public PaginatedList<Income> Income { get;set; }
        public string TotalSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchString,
                string currentFilter, int? pageIndex)
        {
            if (_context.Income != null)
            {
            CurrentSort = sortOrder;
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            TotalSort = sortOrder == "Total" ? "total_desc": "Total";

            if(searchString!= null){
                pageIndex = 1;
            }
            else {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Income> incomeIQ = from s in _context.Income
                                select s;
            
            if (!String.IsNullOrEmpty(searchString))
            {
                incomeIQ = incomeIQ.Where(s => s.Booth.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
            case "Date":
                incomeIQ = incomeIQ.OrderBy(s => s.Date);
                break;
            case "date_desc":
                incomeIQ = incomeIQ.OrderByDescending(s => s.Date);
                break;
            case "Total":
                incomeIQ = incomeIQ.OrderBy(s => s.Total);
                break;
            case "total_desc":
                incomeIQ = incomeIQ.OrderByDescending(s => s.Total);
                break;
            }

            var pageSize = Configuration.GetValue("PageSize", 4);
            Income = await PaginatedList<Income>.CreateAsync(
                incomeIQ.AsNoTracking().Include(e => e.Booth), pageIndex ?? 1, pageSize);

            }
    }
}
}
