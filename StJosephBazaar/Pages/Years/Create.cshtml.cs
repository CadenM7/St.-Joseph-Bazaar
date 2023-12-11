using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using NuGet.Protocol.Plugins;
using StJosephBazaar.Data;
using StJosephBazaar.Models;

namespace StJosephBazaar.Pages.Years
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
        public Year Year {get; set;}


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            Year newYear = new Year();
            if (await TryUpdateModelAsync<Year>(
                    newYear,
                    "year",
                    s => s.Friday, s => s.Saturday, s => s.ID, s => s.YearVal, s => s.Booths))

            {
                newYear.Booths = new HashSet<Booth>();
                Console.WriteLine("UniqueIdTHINGIES" + Year.RefId);
                Year yearBind = _context.Year.Include(y => y.Booths).Where(y => y.ID == Year.RefId).FirstOrDefault();

                if (yearBind != null)
                {
                    foreach (Booth booth in yearBind.Booths)
                    {
                        Booth newBooth = new Booth();
                        newBooth.Year = Year;
                        newBooth.Name = booth.Name;
                        newBooth.YearID = Year.ID;
                        newYear.Booths.Add(newBooth);
                        _context.Booth.Add(newBooth);
                    }
                } else {
                    Console.WriteLine("UniqueFailureMessage");
                    _context.Year.Add(newYear);
                }
                Year.YearRef = null;
                Year.RefId = -1;
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateYearDropDownList(_context);
            return Page();
        }
    }

}
