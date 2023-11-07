using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StJosephBazaar.Models;

namespace StJosephBazaar.Data
{
    public class BazaarContext : DbContext
    {
        public BazaarContext (DbContextOptions<BazaarContext> options)
            : base(options)
        {
        }

        public DbSet<StJosephBazaar.Models.Booth> Booth { get; set; } = default!;

        public DbSet<StJosephBazaar.Models.Startup> Startup { get; set; } = default!;

        public DbSet<StJosephBazaar.Models.Expense> Expense { get; set; } = default!;

        public DbSet<StJosephBazaar.Models.Income> Income { get; set; } = default!;
    }
}
