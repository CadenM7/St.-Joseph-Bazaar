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
using StJosephBazaar.Pages.Courses;

namespace StJosephBazaar.Pages.Incomes
{
    public class EditModel : BoothNamePageModel
    {
        private readonly StJosephBazaar.Data.BazaarContext _context;

        public EditModel(StJosephBazaar.Data.BazaarContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Income Income { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Income == null)
            {
                return NotFound();
            }

            Income = await _context.Income
                .Include(c => c.Booth).FirstOrDefaultAsync(m => m.ID == id);
            
            if (Income == null)
            {
                return NotFound();
            }

            PopulateBoothsDropDownList(_context, Income.BoothID);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incomeToUpdate = await _context.Income.FindAsync(id);

            if (incomeToUpdate == null){
                return NotFound();
            }

            if (await TryUpdateModelAsync<Income>(
                incomeToUpdate,
                "expense",
                 s => s.BoothID, s => s.Date, s => s.HourCollected, s => s.Total))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateBoothsDropDownList(_context, incomeToUpdate.BoothID);
            return Page();
        }
    }
}
