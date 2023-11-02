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

namespace StJosephBazaar.Pages.Startups
{
    public class EditModel : PageModel
    {
        private readonly StJosephBazaar.Data.BazaarContext _context;

        public EditModel(StJosephBazaar.Data.BazaarContext context)
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

            var startup =  await _context.Startup.FirstOrDefaultAsync(m => m.ID == id);
            if (startup == null)
            {
                return NotFound();
            }
            Startup = startup;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Startup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StartupExists(Startup.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StartupExists(int id)
        {
          return (_context.Startup?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
