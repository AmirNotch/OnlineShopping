using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopping.DbContext;
using OnlineShopping.Models;

namespace OnlineShopping
{
    public static class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (!context.Products.Any())
            {
                var products = new List<Product>
                {
                    new Product
                    {
                        Title = "Хлеб",
                        Cost = 150,
                        Photo = "ce4cf9522d_1000"
                    },
                    new Product
                    {
                        Title = "Вода",
                        Cost = 200,
                        Photo = "aa9e83ae8118b941efea31c3e78d9ed9"
                    },
                    new Product
                    {
                        Title = "Курица",
                        Cost = 1500,
                        Photo = "images"
                    },
                    new Product
                    {
                        Title = "Мясо",
                        Cost = 2100,
                        Photo = "8879ec2496_500"
                    },
                    new Product
                    {
                        Title = "Масло",
                        Cost = 500,
                        Photo = "2279418896660e618b9e"
                    },
                    new Product
                    {
                        Title = "Батон",
                        Cost = 200,
                        Photo = "w123dda"
                    }
                };

                await context.Products.AddRangeAsync(products);
                await context.SaveChangesAsync();
            }
        }
    }
}