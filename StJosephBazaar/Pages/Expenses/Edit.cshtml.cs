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

namespace StJosephBazaar.Pages.Expenses
{
    public class EditModel : BoothNamePageModel
    {
        private readonly StJosephBazaar.Data.BazaarContext _context;

        public EditModel(StJosephBazaar.Data.BazaarContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Expense Expense { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Expense == null)
            {
                return NotFound();
            }

            Expense = await _context.Expense
                .Include(c => c.Booth).FirstOrDefaultAsync(m => m.ID == id);

            if (Expense == null)
            {
                return NotFound();
            }
            PopulateBoothsDropDownList(_context, Expense.BoothID);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if(id == null){
                return NotFound();
            }

            var expenseToUpdate = await _context.Expense.FindAsync(id);

            if(expenseToUpdate == null){
                return NotFound();
            }

            if (await TryUpdateModelAsync<Expense>(
                expenseToUpdate,
                "expense",
                 s => s.BoothID, s => s.InvoiceNum, s => s.CheckNum, s => s.Date, s => s.Description, s => s.Total))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateBoothsDropDownList(_context, expenseToUpdate.BoothID);
            return Page();
        }

        private bool ExpenseExists(int id)
        {
          return (_context.Expense?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
