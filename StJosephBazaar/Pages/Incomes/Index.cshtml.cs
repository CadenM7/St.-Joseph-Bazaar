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

namespace StJosephBazaar.Pages.Incomes
{
    public class IndexModel : PageModel
    {
        private readonly StJosephBazaar.Data.BazaarContext _context;

        public IndexModel(StJosephBazaar.Data.BazaarContext context)
        {
            _context = context;
        }

        public IList<Income> Income { get;set; } = default!;
        
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Names { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? BoothName { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.Income != null)
            {
                Income = await _context.Income
                .Include(i => i.Booth).ToListAsync();
            
                var incomes = from m in _context.Income
                                        select m;
                if (!string.IsNullOrEmpty(SearchString))
                {
                    incomes = incomes.Where(s => s.Booth.Name.Contains(SearchString));
                }

                    Income = await incomes.ToListAsync();
            }
        }
    }
}
