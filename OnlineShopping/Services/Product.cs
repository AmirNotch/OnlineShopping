using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace OnlineShopping.Services
{
    public class Product : IProduct
    {
        private readonly DataContext _dataContext;

        public Product(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        public async Task<List<Product>> GetProducts()
        {
            /*return await _dataContext.Products.OrderBy<Prod>(x => x.Title).ToListAsync();*/
            return new List<Product>();
        }
    }
}