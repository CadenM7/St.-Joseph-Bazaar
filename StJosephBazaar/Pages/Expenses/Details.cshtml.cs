using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StJosephBazaar.Data;
using StJosephBazaar.Models;

namespace StJosephBazaar.Pages.Expenses
{
    public class DetailsModel : PageModel
    {
        private readonly StJosephBazaar.Data.BazaarContext _context;

        public DetailsModel(StJosephBazaar.Data.BazaarContext context)
        {
            _context = context;
        }

      public Expense Expense { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Expense == null)
            {
                return NotFound();
            }

            Expense = await _context.Expense
                .AsNoTracking()
                .Include(c => c.Booth)
                .FirstOrDefaultAsync(m => m.ID == id);
            
            if (Expense == null)
            {
                return NotFound();
            }
            
            return Page();
        }
    }
}
