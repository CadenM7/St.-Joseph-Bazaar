using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StJosephBazaar.Data;
using StJosephBazaar.Models;

namespace StJosephBazaar.Pages.Startups
{
    public class CreateModel : PageModel
    {
        private readonly StJosephBazaar.Data.BazaarContext _context;

        public CreateModel(StJosephBazaar.Data.BazaarContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Startup Startup { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Startup == null || Startup == null)
            {
                return Page();
            }

            _context.Startup.Add(Startup);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
