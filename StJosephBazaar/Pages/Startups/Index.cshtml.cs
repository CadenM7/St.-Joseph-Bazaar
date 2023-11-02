using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StJosephBazaar.Data;
using StJosephBazaar.Models;

namespace StJosephBazaar.Pages.Startups
{
    public class IndexModel : PageModel
    {
        private readonly StJosephBazaar.Data.BazaarContext _context;

        public IndexModel(StJosephBazaar.Data.BazaarContext context)
        {
            _context = context;
        }

        public IList<Startup> Startup { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Startup != null)
            {
                Startup = await _context.Startup.ToListAsync();
            }
        }
    }
}
