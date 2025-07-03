// Data/ApplicationDbContext.cs
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using sharp_recruit.Models;

namespace sharp_recruit.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        // Add your DB sets here
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Keep this to preserve default behavior

            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasDefaultValue("User");
        }
    }
}
