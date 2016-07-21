using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beta.Models
{
    public class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions options): base(options) { }

        public DbSet<Demo> Demos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<Demo>().HasKey(m => m.Id);
            base.OnModelCreating(builder);
        }
    }
}
