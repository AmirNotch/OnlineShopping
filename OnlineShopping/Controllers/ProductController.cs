using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Products;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace OnlineShopping.Controllers
{
    public class ProductController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts() =>  await Mediator.Send(new List.Query());

        [HttpPost]
        public async Task<IActionResult> Paying([FromBody] List<Log> productsList)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\ibrag\RiderProjects\OnlineShopping\Persistence\NumberOfGoods.txt");
            var numberOfGoods = Int32.Parse(lines[lines.Length - 1]);
            foreach (var product in productsList)
            {
                product.Id = new Guid();
                product.Count = 1;
                product.Payed = "Оплачено";
                product.StatusManager = "Ждёт выполнения";
                product.NumberOfGood = numberOfGoods;
            }

            return Ok(await Mediator.Send(new Create.Command {Logs = productsList}));
        }
    }
}