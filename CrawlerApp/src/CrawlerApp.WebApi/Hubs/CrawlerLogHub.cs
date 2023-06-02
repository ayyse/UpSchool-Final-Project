using CrawlerApp.Application.Common.Models.Crawler;
using CrawlerApp.Application.Common.Models.Product;
using Microsoft.AspNetCore.SignalR;

namespace CrawlerApp.WebApi.Hubs
{
    public class CrawlerLogHub : Hub
    {
        public async Task SendLogNotificationAsync(CrawlerLogDto log)
        {
            await Clients.AllExcept(Context.ConnectionId).SendAsync("NewSeleniumLogAdded", log);
        }

        public async Task GetAllProductsAsync(ProductDto product)
        {
            await Clients.AllExcept(Context.ConnectionId).SendAsync("GetAll", product);
        }
    }
}
