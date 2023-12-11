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
    public class DetailsModel : PageModel
    {
        private readonly StJosephBazaar.Data.BazaarContext _context;

        public DetailsModel(StJosephBazaar.Data.BazaarContext context)
        {
            _context = context;
        }

      public Comparison Comparison { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Comparison == null)
            {
                return NotFound();
            }

            var comparison = await _context.Comparison.FirstOrDefaultAsync(m => m.ID == id);
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
    }
}
