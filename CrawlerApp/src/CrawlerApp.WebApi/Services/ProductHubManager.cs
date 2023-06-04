using CrawlerApp.Application.Common.Interfaces;
using CrawlerApp.Application.Common.Models.Product;
using CrawlerApp.WebApi.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace CrawlerApp.WebApi.Services
{
    public class ProductHubManager : IProductHubService
    {
        private readonly IHubContext<CrawlerLogHub> _hubContext;

        public ProductHubManager(IHubContext<CrawlerLogHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public Task AddProductAsync(ProductDto product, CancellationToken cancellationToken)
        {
            return _hubContext.Clients.All.SendAsync("AddProduct", product, cancellationToken);
        }
    }
}
