using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StJosephBazaar.Data;
using StJosephBazaar.Models;

namespace StJosephBazaar.Pages.Startups
{
    public class DetailsModel : PageModel
    {
        private readonly StJosephBazaar.Data.BazaarContext _context;

        public DetailsModel(StJosephBazaar.Data.BazaarContext context)
        {
            _context = context;
        }

      public Startup Startup { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Startup == null)
            {
                return NotFound();
            }

            var startup = await _context.Startup.FirstOrDefaultAsync(m => m.ID == id);
            if (startup == null)
            {
                return NotFound();
            }
            else 
            {
                Startup = startup;
            }
            return Page();
        }
    }
}
