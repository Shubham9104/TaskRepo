using Microsoft.EntityFrameworkCore;
using Restaurant.web.Model;
using Restaurant.web.Models;

namespace Restaurant.web.Data
{
    public class ApplicationDbContext:DbContext
    {

        public DbSet<Customers> Customers { get; set; }

        public DbSet<Foodmenu> Foodmenu { get; set; }
        public DbSet<Orders> orders { get; set; }

        public DbSet<FoodCategory> FoodCategory { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    }



}
