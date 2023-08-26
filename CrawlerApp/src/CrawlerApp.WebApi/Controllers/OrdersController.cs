using CrawlerApp.Application.Features.Orders.Commands.Add;
using CrawlerApp.Application.Features.Orders.Queries.GetAll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrawlerApp.WebApi.Controllers
{
    public class OrdersController : ApiControllerBase
    {
        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAllAsync(OrderGetAllQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(OrderAddCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
