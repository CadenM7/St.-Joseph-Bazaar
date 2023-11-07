using StJosephBazaar.Data;
using StJosephBazaar.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace StJosephBazaar.Pages.Courses
{
    public class BoothNamePageModel : PageModel
    {
        public SelectList BoothNameSL { get; set; }

        public void PopulateBoothsDropDownList(BazaarContext _context,
            object selectedBooth = null)
        {
            var boothQuery = from d in _context.Booth
                                   orderby d.Name // Sort by name.
                                   select d;

            BoothNameSL = new SelectList(boothQuery.AsNoTracking(),
                nameof(Booth.Id),
                nameof(Booth.Name),
                selectedBooth);
        }
    }
}