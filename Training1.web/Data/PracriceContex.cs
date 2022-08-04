using Training1.web;
using Training1.web.Models;
using Microsoft.EntityFrameworkCore;
using Training1.web.Model;

namespace Training1.web.Data
{
    public class PracticeContex : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }



        public PracticeContex(DbContextOptions<PracticeContex> options) : base(options)
        {

        }


    }
}