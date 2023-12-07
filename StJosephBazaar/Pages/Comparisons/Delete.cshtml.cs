using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StJosephBazaar.Data;
using StJosephBazaar.Models;

namespace StJosephBazaar.Pages.Comparisons
{
    public class DeleteModel : PageModel
    {
        private readonly StJosephBazaar.Data.BazaarContext _context;

        public DeleteModel(StJosephBazaar.Data.BazaarContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Comparison Comparison { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Comparison == null)
            {
                return NotFound();
            }

            var comparison = await _context.Comparison.FirstOrDefaultAsync(m => m.ComparisonID == id);

            if (comparison == null)
            {
                return NotFound();
            }
            else 
            {
                Comparison = comparison;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Comparison == null)
            {
                return NotFound();
            }
            var comparison = await _context.Comparison.FindAsync(id);

            if (comparison != null)
            {
                Comparison = comparison;
                _context.Comparison.Remove(Comparison);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
