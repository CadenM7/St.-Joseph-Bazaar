using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StJosephBazaar.Data;
using StJosephBazaar.Models;
using StJosephBazaar.Page.Comparisons;

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
        public Comparison Comparison { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          var emptyComp = new Comparison();
                if(await TryUpdateModelAsync<Comparison>(
                        emptyComp,
                        "comparison",
                        s => s.ComparisonID, s => s.InitID, s => s.CompID))

                    {
                        _context.Comparison.Add(emptyComp);
                        await _context.SaveChangesAsync();
                        return RedirectToPage("./Index");
                    }

                    PopulateYearDropDownList(_context, emptyComp.InitID);
                    PopulateYearDropDownList(_context, emptyComp.CompID);
                    return Page();
                }
        }
    }
