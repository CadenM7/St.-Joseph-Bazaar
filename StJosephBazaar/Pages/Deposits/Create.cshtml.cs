using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StJosephBazaar.Data;
using StJosephBazaar.Models;

namespace StJosephBazaar.Pages.Deposits
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
        public Deposit Deposit { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Deposit == null || Deposit == null)
            {
                return Page();
            }

            var emptyDeposit = new Deposit();
            if(await TryUpdateModelAsync<Deposit>(
                    emptyDeposit,
                    "deposit",
                    s => s.YearID, s=> s.Checks, s => s.Twentys, s=> s.Tens, s => s.Fives, s => s.Ones, s => s.Quarters, s => s.Dimes, s => s.Nickels, s => s.Pennies, s => s.Other_Change))

                {
                    _context.Deposit.Add(emptyDeposit);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }

                PopulateYearDropDownList(_context, emptyDeposit.YearID);
                return Page();
        }
    }
}
