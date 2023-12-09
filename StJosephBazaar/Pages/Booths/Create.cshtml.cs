using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StJosephBazaar.Data;
using StJosephBazaar.Models;
using StJosephBazaar.Pages.Booths;

namespace StJosephBazaar.Pages.Booths
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
        public Booth Booth { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyBooth = new Booth();
            if(await TryUpdateModelAsync<Booth>(
                    emptyBooth,
                    "booth",
                    s => s.YearID, s=> s.Name, s => s.Friday, s => s.Saturday, s => s.Auction, s => s.Gross_Revenue, s => s.Purchases, s => s.Expenses, s => s.Income, s => s.Net_Income))

                {
                    _context.Booth.Add(emptyBooth);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }

                PopulateYearDropDownList(_context, emptyBooth.YearID);
                return Page();
            }
    }
}
