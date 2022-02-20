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
                        Photo = "bread-46"
                    },
                    new Product
                    {
                        Title = "Вода",
                        Cost = 200,
                        Photo = "Без названия (2)"
                    },
                    new Product
                    {
                        Title = "Курица",
                        Cost = 1500,
                        Photo = "e8605a0651d8c2092c2674ce194a933d"
                    },
                    new Product
                    {
                        Title = "Мясо",
                        Cost = 2100,
                        Photo = "мясо-косшы-"
                    },
                    new Product
                    {
                        Title = "Масло",
                        Cost = 500,
                        Photo = "istockphoto-149044379-170667a"
                    },
                    new Product
                    {
                        Title = "Батон",
                        Cost = 200,
                        Photo = "images (1)"
                    },
                    new Product
                    {
                        Title = "Piko-Pulpy",
                        Cost = 400,
                        Photo = "Без названия (3)"
                    },
                    new Product
                    {
                        Title = "Snickers",
                        Cost = 160,
                        Photo = "snickers-chocolate-bar-50-g-0-20210312"
                    },
                    new Product
                    {
                        Title = "Kitkat",
                        Cost = 220,
                        Photo = "2544-01"
                    }
                };

                await context.Products.AddRangeAsync(products);
                await context.SaveChangesAsync();
            }
        }
    }
}