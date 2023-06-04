using CrawlerApp.Application.Features.Orders.Commands.Add;
using Microsoft.AspNetCore.Mvc;

namespace CrawlerApp.WebApi.Controllers
{
    public class OrdersController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddAsync(OrderAddCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
