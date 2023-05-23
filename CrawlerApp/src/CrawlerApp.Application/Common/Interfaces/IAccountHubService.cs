using CrawlerApp.Application.Common.Models.Crawler;
using CrawlerApp.Application.Common.Models.Product;
using CrawlerApp.Application.Features.Products.Commands.Add;

namespace CrawlerApp.Application.Common.Interfaces
{
    public interface IAccountHubService
    {
        Task SendLogNotificationAsync(CrawlerLogDto log);
        Task AddProductAsync(ProductDto product, CancellationToken cancellationToken);
    }
}
