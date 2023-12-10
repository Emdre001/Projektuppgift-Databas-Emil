using Microsoft.EntityFrameworkCore;
using Projektuppgift_Databas_Emil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektuppgift_Databas_Emil.Data
{
    internal class Context : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<LoanDetail> LoanDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"
                Server=localhost;
                Database=NewtonLibrary Emil;
                Trusted_Connection=True;
                Trust Server Certificate=Yes;
                User Id=NewtonLibrary;
                password=NewtonLibrary");

        }
    }
}
