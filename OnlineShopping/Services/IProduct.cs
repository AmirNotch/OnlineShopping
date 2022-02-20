using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineShopping.Models;

namespace OnlineShopping.Services
{
    public interface IProduct
    {
        Task<List<Models.Product>> GetProducts();
    }
}