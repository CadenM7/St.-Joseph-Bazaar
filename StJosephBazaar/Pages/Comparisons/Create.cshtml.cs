using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StJosephBazaar.Data;
using StJosephBazaar.Models;

namespace StJosephBazaar.Pages.Comparisons
{
    public class CreateModel : YearPageModel
    {
        private readonly StJosephBazaar.Data.BazaarContext _context;

        public CreateModel(StJosephBazaar.Data.BazaarContext context)
        {
            _context = context;
        }
        

        public IActionResult OnGet()
        {
            PopulateYearDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Comparison Comparison { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyComparison = new Comparison();
            if(await TryUpdateModelAsync<Comparison>(
                    emptyComparison,
                    "booth",
                    s=> s.InitID, s => s.YCAdvance, s => s.YIAdvance))

                {
                    _context.Comparison.Add(emptyComparison);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }

                PopulateYearDropDownList(_context, emptyComparison.InitID);
                return Page();
            }
    }
}
