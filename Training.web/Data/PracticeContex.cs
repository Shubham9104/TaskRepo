using Training.web;
using Training.web.Models;
using Microsoft.EntityFrameworkCore;
namespace Training.web.Data
{
    public class PracticeContex : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }
        public PracticeContex(DbContextOptions<PracticeContex> options) : base(options)
        {

        }


    }
}