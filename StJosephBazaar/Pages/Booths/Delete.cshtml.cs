using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StJosephBazaar.Data;
using StJosephBazaar.Models;

namespace StJosephBazaar.Pages.Booths
{
    public class DeleteModel : PageModel
    {
        private readonly StJosephBazaar.Data.BazaarContext _context;

        public DeleteModel(StJosephBazaar.Data.BazaarContext context)
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

            var booth = await _context.Booth.FirstOrDefaultAsync(m => m.Id == id);

            if (booth == null)
            {
                return NotFound();
            }
            else 
            {
                Booth = booth;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Booth == null)
            {
                return NotFound();
            }
            var booth = await _context.Booth.FindAsync(id);

            if (booth != null)
            {
                Booth = booth;
                _context.Booth.Remove(Booth);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
