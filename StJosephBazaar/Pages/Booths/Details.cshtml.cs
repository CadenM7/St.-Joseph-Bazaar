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
    public class DetailsModel : PageModel
    {
        private readonly StJosephBazaar.Data.BazaarContext _context;

        public DetailsModel(StJosephBazaar.Data.BazaarContext context)
        {
            _context = context;
        }

      public Booth Booth { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Booth == null)
            {
                return NotFound();
            }

            Booth = await _context.Booth
            .AsNoTracking()
            .Include(c => c.Year)
            .FirstOrDefaultAsync(m => m.Id == id);
            
            if (Booth == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
