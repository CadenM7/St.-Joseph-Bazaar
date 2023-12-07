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

namespace StJosephBazaar.Pages.Booths
{
    public class EditModel : YearPageModel
    {
        private readonly StJosephBazaar.Data.BazaarContext _context;

        public EditModel(StJosephBazaar.Data.BazaarContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Booth Booth { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Booth == null)
            {
                return NotFound();
            }

            Booth =  await _context.Booth
                .Include(c => c.Year).FirstOrDefaultAsync(m => m.Id == id);
            
            if (Booth == null)
            {
                return NotFound();
            }
            PopulateYearDropDownList(_context, Booth.YearID);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            //context.Attach(Booth).State = EntityState.Modified;
            
            var boothToUpdate = await _context.Booth.FindAsync(id);
            
            if(boothToUpdate == null){
                return NotFound();
            }

            if(await TryUpdateModelAsync<Booth>(
                boothToUpdate,
                "booth",
                s => s.YearID, s=> s.Name, s => s.Friday, s => s.Saturday, s => s.Auction, s => s.Gross_Revenue, s => s.Purchases, s => s.Expenses, s => s.Income, s => s.Net_Income))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateYearDropDownList(_context, boothToUpdate.YearID);
            return Page();
            // try
            // {
            //     await _context.SaveChangesAsync();
            // }
            // catch (DbUpdateConcurrencyException)
            // {
            //     if (!BoothExists(Booth.Id))
            //     {
            //         return NotFound();
            //     }
            //     else
            //     {
            //         throw;
            //     }
            // }

            //return RedirectToPage("./Index");
        }

        private bool BoothExists(int id)
        {
          return (_context.Booth?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
