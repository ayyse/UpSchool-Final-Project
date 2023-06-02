using CrawlerApp.Application.Features.Products.Commands.Add;
using Microsoft.AspNetCore.Mvc;

namespace CrawlerApp.WebApi.Controllers
{
    public class ProductsController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddAsync(ProductAddCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
