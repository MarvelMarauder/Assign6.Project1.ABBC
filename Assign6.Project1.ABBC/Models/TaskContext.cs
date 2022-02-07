using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assign6.Project1.ABBC.Models
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
            //leave blank
        }

        public DbSet<TaskResponse> EffectiveTasks { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {

            mb.Entity<Category>().HasData(                  // prepopulated Category fields
                    new Category { CategoryId = 1, CategoryName = "Home" },
                    new Category { CategoryId = 2, CategoryName = "School" },
                    new Category { CategoryId = 3, CategoryName = "Work" },
                    new Category { CategoryId = 4, CategoryName = "Church" }
                );
            mb.Entity<TaskResponse>().HasData(

                new TaskResponse
                {
                    TaskId = 1,
                    CategoryId = 2,
                    Task = "Add Models",
                    DueDate = "Feb 9",
                    Quadrant = 1,
                    Completed = true,
                },
                new TaskResponse
                {
                    TaskId = 2,
                    CategoryId = 2,
                    Task = "Add Views",
                    DueDate = "Feb 9",
                    Quadrant = 1,
                    Completed = true,
                },
                new TaskResponse
                {
                    TaskId = 3,
                    CategoryId = 2,
                    Task = "Add Quadrant View",
                    DueDate = "Feb 9",
                    Quadrant = 1,
                    Completed = true,
                }
                );
        }
    }
}
