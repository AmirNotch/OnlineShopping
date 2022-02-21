using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence
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
                        Photo = "bread-46",
                        Address = "1"
                    },
                    new Product
                    {
                        Title = "Вода",
                        Cost = 200,
                        Photo = "Без названия (2)",
                        Address = "1"
                    },
                    new Product
                    {
                        Title = "Курица",
                        Cost = 1500,
                        Photo = "e8605a0651d8c2092c2674ce194a933d",
                        Address = "1"
                    },
                    new Product
                    {
                        Title = "Мясо",
                        Cost = 2100,
                        Photo = "мясо-косшы-",
                        Address = "1"
                    },
                    new Product
                    {
                        Title = "Масло",
                        Cost = 500,
                        Photo = "istockphoto-149044379-170667a",
                        Address = "1"
                    },
                    new Product
                    {
                        Title = "Батон",
                        Cost = 200,
                        Photo = "images (1)",
                        Address = "1"
                    },
                    new Product
                    {
                        Title = "Piko-Pulpy",
                        Cost = 400,
                        Photo = "Без названия (3)",
                        Address = "1"
                    },
                    new Product
                    {
                        Title = "Snickers",
                        Cost = 160,
                        Photo = "snickers-chocolate-bar-50-g-0-20210312",
                        Address = "1"
                    },
                    new Product
                    {
                        Title = "Kitkat",
                        Cost = 220,
                        Photo = "2544-01",
                        Address = "1"
                    },
                    new Product
                    {
                        Title = "Sprite",
                        Cost = 395,
                        Photo = "e1bdd2ab70cb9fb26e8149a927b9ba68",
                        Address = "1"
                    },
                    new Product
                    {
                        Title = "Макароны MAKFA",
                        Cost = 450,
                        Photo = "makarony_makfa_ulitki_400_g_1_full",
                        Address = "1"
                    },
                    new Product
                    {
                        Title = "Choco-Pie",
                        Cost = 350,
                        Photo = "pechene_lotte_choco_pie_prosloennoe_glazirovannoe_v_kartonnoy_upakovke_336_g_12_shtuk_kh_28_g_1_full",
                        Address = "1"
                    }
                };

                await context.Products.AddRangeAsync(products);
                await context.SaveChangesAsync();
            }
        }
    }
}