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

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Names { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? BoothName { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.Expense != null)
            {
                Expense = await _context.Expense
                .Include(e => e.Booth).ToListAsync();
            
            
            var expenses = from m in _context.Expense
                                        select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                expenses = expenses.Where(s => s.Booth.Name.Contains(SearchString));
            }

                Expense = await expenses.ToListAsync();
            }
        }
    }
}
