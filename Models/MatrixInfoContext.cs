using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission8_Group2.Models
{
    public class MatrixInfoContext : DbContext
    {
        //Constructor
        public MatrixInfoContext (DbContextOptions <MatrixInfoContext> options) :base(options)
        {

        }

        public DbSet<MatrixResponse> responses { get; set; }

        public DbSet<Category> Categories { get; set; }

        //Seed the data

        protected override void OnModelCreating(ModelBuilder Mb)
        {
            Mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Urgent/Important" },
                new Category { CategoryId = 2, CategoryName = "Urgent/Unimportant" },
                new Category { CategoryId = 3, CategoryName = "Not Urgent/Important" },
                new Category { CategoryId = 4, CategoryName = "Not Urgent/Unimportant" }

            );

            Mb.Entity<MatrixResponse>().HasData(

                new MatrixResponse
                {
                    MatrixId = 1,
                    Task = "Vacuuming the lawn",
                    DueDate = "Tomorrow",
                    Quadrant = 1,
                    Completed = true,
                    CategoryId = 1,
                },

                new MatrixResponse
                {
                    MatrixId = 2,
                    Task = "Study for IS 404 Test",
                    DueDate = "2/24/23",
                    Quadrant = 2,
                    Completed = false,
                    CategoryId = 2,
                },

                new MatrixResponse
                {
                    MatrixId = 4,
                    Task = "Play Minecraft",
                    DueDate = "Erry Day",
                    Quadrant = 4,
                    Completed = true,
                    CategoryId = 4,
                }
            );
        }
    }
}