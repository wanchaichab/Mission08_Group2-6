using System;
using Microsoft.EntityFrameworkCore;

namespace Mission08_Group2_6.Models
{
    public class TaskEntryContext : DbContext
    {
        public TaskEntryContext(DbContextOptions<TaskEntryContext> options) : base(options)
        {

        }

        public DbSet<TaskEntry> Entries { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder ab)
        {
            ab.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Home" },
                new Category { CategoryId = 2, CategoryName = "School" },
                new Category { CategoryId = 3, CategoryName = "Work" },
                new Category { CategoryId = 4, CategoryName = "Church" }
            );
        }
    }
}
