using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mofdisplay.Models;

namespace mofdisplay.Data
{
    public class mofdisplayContext : DbContext
    {
        public mofdisplayContext (DbContextOptions<mofdisplayContext> options)
            : base(options)
        {
        }

        public DbSet<mofdisplay.Models.Contributor> Contributors { get; set; } = default!;
        public DbSet<mofdisplay.Models.Kit> Kits { get; set; }
        public DbSet<mofdisplay.Models.Display> Displays { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contributor>().ToTable("Contributor");
            modelBuilder.Entity<Kit>().ToTable("Kit");
            modelBuilder.Entity<Display>().ToTable("Display");
        }
    }
}
