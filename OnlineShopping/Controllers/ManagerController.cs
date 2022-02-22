using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Products;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.Controllers
{
    public class ManagerController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Log>>> GetLogs()
        {
            return await Mediator.Send(new ListLogs.Query());
        }

        [HttpPost]
        public async Task<IActionResult> Done([FromBody] Log log)
        {
            return Ok(await Mediator.Send(new Edit.Command {Log = log}));
        }
    }
}