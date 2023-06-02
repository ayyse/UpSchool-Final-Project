using CrawlerApp.Application.Common.Models.Product;
using CrawlerApp.Application.Features.Products.Commands.Add;

namespace CrawlerApp.Application.Common.Interfaces
{
    public interface IProductHubService
    {
        Task AddProductAsync(ProductDto product, CancellationToken cancellationToken);
    }
}
