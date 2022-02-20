using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.DbContext;

namespace OnlineShopping.Services
{
    public class Product : IProduct
    {
        private readonly DataContext _dataContext;

        public Product(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        public async Task<List<Models.Product>> GetProducts()
        {
            return await _dataContext.Products.OrderBy(x => x.Title).ToListAsync();
        }
    }
}