using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StJosephBazaar.Data;
using StJosephBazaar.Models;

namespace StJosephBazaar.Pages.Deposits
{
    public class DetailsModel : PageModel
    {
        private readonly StJosephBazaar.Data.BazaarContext _context;

        public DetailsModel(StJosephBazaar.Data.BazaarContext context)
        {
            _context = context;
        }

      public Deposit Deposit { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Deposit == null)
            {
                return NotFound();
            }

            var deposit = await _context.Deposit.FirstOrDefaultAsync(m => m.ID == id);
            if (deposit == null)
            {
                return NotFound();
            }
            else 
            {
                Deposit = deposit;
            }
            return Page();
        }
    }
}
