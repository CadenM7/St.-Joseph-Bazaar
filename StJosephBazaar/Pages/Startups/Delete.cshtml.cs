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
    public class DeleteModel : PageModel
    {
        private readonly StJosephBazaar.Data.BazaarContext _context;

        public DeleteModel(StJosephBazaar.Data.BazaarContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Startup == null)
            {
                return NotFound();
            }
            var startup = await _context.Startup.FindAsync(id);

            if (startup != null)
            {
                Startup = startup;
                _context.Startup.Remove(Startup);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
