using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using StJosephBazaar.Data;
using StJosephBazaar.Models;

namespace StJosephBazaar.Pages.Expenses
{
    public class IndexModel : PageModel
    {
        private readonly StJosephBazaar.Data.BazaarContext _context;

        public IndexModel(StJosephBazaar.Data.BazaarContext context)
        {
            _context = context;
        }

        public IList<Expense> Expense { get;set; } = default!;
        //public string TotalSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            if (_context.Expense != null)
            {
            
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            //TotalSort = sortOrder == "Total" ? "total_desc": "Total";

            CurrentFilter = searchString;

            IQueryable<Expense> expenseIQ = from s in _context.Expense
                                select s;
            
            if (!String.IsNullOrEmpty(searchString))
            {
                expenseIQ = expenseIQ.Where(s => s.Booth.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
            case "Date":
                expenseIQ = expenseIQ.OrderBy(s => s.Date);
                break;
            case "date_desc":
                expenseIQ = expenseIQ.OrderByDescending(s => s.Date);
                break;
            //case "Total":
                //expenseIQ = expenseIQ.OrderBy(s => s.Total);
                //break;
            //case "total_desc":
                //expenseIQ = expenseIQ.OrderByDescending(s => s.Total);
                //break;
            }

            Expense = await expenseIQ.AsNoTracking().Include(e => e.Booth).ToListAsync();
            }
        }
    }
}
