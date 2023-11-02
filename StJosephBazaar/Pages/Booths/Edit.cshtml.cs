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

namespace StJosephBazaar.Pages.Booths
{
    public class EditModel : PageModel
    {
        private readonly StJosephBazaar.Data.BazaarContext _context;

        public EditModel(StJosephBazaar.Data.BazaarContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Booth Booth { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Booth == null)
            {
                return NotFound();
            }

            var booth =  await _context.Booth.FirstOrDefaultAsync(m => m.Id == id);
            if (booth == null)
            {
                return NotFound();
            }
            Booth = booth;
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

            _context.Attach(Booth).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoothExists(Booth.Id))
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

        private bool BoothExists(int id)
        {
          return (_context.Booth?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
