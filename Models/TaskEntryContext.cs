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
    }
}

