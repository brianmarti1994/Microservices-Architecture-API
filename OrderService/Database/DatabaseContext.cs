using Microsoft.EntityFrameworkCore;
using OrderService.Database.Entities;

namespace OrderService.Database
{
    public class DatabaseContext:DbContext
    {

        public DbSet<Order> Orders { get; set; }
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=BRIANLAPTOP;initial catalog=OrderMicroservice;user id=SA");
        }
    }
}
