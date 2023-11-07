using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StJosephBazaar.Data;
using StJosephBazaar.Models;

namespace StJosephBazaar.Pages.Incomes
{
    public class DetailsModel : PageModel
    {
        private readonly StJosephBazaar.Data.BazaarContext _context;

        public DetailsModel(StJosephBazaar.Data.BazaarContext context)
        {
            _context = context;
        }

      public Income Income { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Income == null)
            {
                return NotFound();
            }

            Income = await _context.Income
                .AsNoTracking()
                .Include(c => c.Booth)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Income == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
