using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShopping.Services
{
    public interface IProduct
    {
        Task<List<Product>> GetProducts();
    }
}