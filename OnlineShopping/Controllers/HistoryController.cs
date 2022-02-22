using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Products;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.Controllers
{
    public class HistoryController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<AllLog>>> GetLogs() => await Mediator.Send(new ListOfStories.Query());
    }
}