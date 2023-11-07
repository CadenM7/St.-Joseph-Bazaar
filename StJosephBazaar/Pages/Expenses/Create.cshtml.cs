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

namespace StJosephBazaar.Pages.Expenses
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
        public Expense Expense { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          var emptyExpense = new Expense();

          if(await TryUpdateModelAsync<Expense>(
                emptyExpense,
                "expense",
                s => s.BoothID, s => s.Date, s => s.Description, s => s.Total))

            {
                _context.Expense.Add(emptyExpense);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateBoothsDropDownList(_context, emptyExpense.BoothID);
            return Page();
        }
    }
}
