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

namespace StJosephBazaar.Pages.Deposits
{
    public class EditModel : YearPageModel
    {
        private readonly StJosephBazaar.Data.BazaarContext _context;

        public EditModel(StJosephBazaar.Data.BazaarContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Deposit Deposit { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Deposit == null)
            {
                return NotFound();
            }

            var deposit =  await _context.Deposit.FirstOrDefaultAsync(m => m.ID == id);
            if (deposit == null)
            {
                return NotFound();
            }
            Deposit = deposit;
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

            _context.Attach(Deposit).State = EntityState.Modified;

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


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepositExists(Deposit.ID))
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

        private bool DepositExists(int id)
        {
          return (_context.Deposit?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
