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
            var emptyStartup = new Startup();
            if(await TryUpdateModelAsync<Booth>(
                    emptyBooth,
                    "booth",
                    s => s.YearID, s=> s.Name, s => s.Friday, s => s.Saturday, s => s.Auction, s => s.Gross_Revenue, s => s.Purchases, s => s.Expenses, s => s.Net_Income))

                {
                    Year yearBind = _context.Year.Include(y => y.Booths).Where(y => y.ID == emptyBooth.YearID).FirstOrDefault();
                    Console.WriteLine("Unique Unidentifier" + " " + yearBind.YearVal);
                    if(yearBind.Booths != null){
                        yearBind.Booths.Add(emptyBooth);
                    }
                    Console.WriteLine("UniqueIdentifier" + yearBind.Booths.Count);
                    emptyStartup.BoothName = emptyBooth.Name;
                    //_context.Booth.Add(emptyBooth);
                    _context.Startup.Add(emptyStartup);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }

                PopulateYearDropDownList(_context, emptyBooth.YearID);
                return Page();
            }
    }
}
