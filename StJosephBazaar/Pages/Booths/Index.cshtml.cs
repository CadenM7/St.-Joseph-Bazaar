using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StJosephBazaar.Data;
using StJosephBazaar.Models;

namespace StJosephBazaar.Pages.Booths
{
    public class IndexModel : PageModel
    {
        private readonly StJosephBazaar.Data.BazaarContext _context;
        public string YearSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IndexModel(StJosephBazaar.Data.BazaarContext context)
        {
            _context = context;
        }

        public IList<Booth> Booth { get;set; } = default!;

        public IList<Income> Incomes { get;set; } = default!;


        public async Task OnGetAsync(string sortOrder, string searchString,
                string currentFilter, int? pageIndex)
        {
            CurrentSort = sortOrder;
            YearSort = sortOrder == "Year" ? "year_desc" : "Year";

            if(searchString!= null){
                pageIndex = 1;
            }
            else {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Year> yearIQ = from s in _context.Year
                                            select s;

             if (!String.IsNullOrEmpty(searchString))
            {
                Console.WriteLine("Searching for Matching Years" + searchString);
                yearIQ = yearIQ.Where(s => s.YearVal.Contains(searchString));
            }

            switch (sortOrder)
            {
            case "Year":
                yearIQ = yearIQ.OrderBy(s => s.YearVal);
                break;
            case "date_desc":
                yearIQ = yearIQ.OrderByDescending(s => s.YearVal);
                break;
            }

            if (_context.Booth != null)
            {
                Booth = await _context.Booth.Include(e => e.Year).ToListAsync();
        }
    }
}
}
