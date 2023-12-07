using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StJosephBazaar.Data;
using StJosephBazaar.Models;

namespace StJosephBazaar.Pages.Years
{
    public class DetailsModel : PageModel
    {
        private readonly StJosephBazaar.Data.BazaarContext _context;

        public DetailsModel(StJosephBazaar.Data.BazaarContext context)
        {
            _context = context;
        }

      public Year Year { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Year == null)
            {
                return NotFound();
            }

            var year = await _context.Year.FirstOrDefaultAsync(m => m.YearID == id);
            if (year == null)
            {
                return NotFound();
            }
            else 
            {
                Year = year;
            }
            return Page();
        }
    }
}
