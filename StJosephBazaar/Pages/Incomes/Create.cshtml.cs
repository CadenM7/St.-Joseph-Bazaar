using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StJosephBazaar.Data;
using StJosephBazaar.Models;
using StJosephBazaar.Pages.Courses;

namespace StJosephBazaar.Pages.Incomes
{
    public class CreateModel : BoothNamePageModel
    {
        private readonly StJosephBazaar.Data.BazaarContext _context;

        public CreateModel(StJosephBazaar.Data.BazaarContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateBoothsDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Income Income { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyIncome = new Income();

            if (await TryUpdateModelAsync<Income>(
                emptyIncome,
                "income",
                s => s.BoothID, s => s.Date, s => s.HourCollected, s => s.Total))
                {
                    _context.Income.Add(emptyIncome);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");                    
                }

                PopulateBoothsDropDownList(_context, emptyIncome.BoothID);
                return Page();
        }
    }
}
