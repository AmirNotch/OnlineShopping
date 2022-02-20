using Microsoft.EntityFrameworkCore;
using OnlineShopping.Models;

namespace OnlineShopping.DbContext
{
    public class DataContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }
        
        public DbSet<Product> Products { get; set; }
    }
}