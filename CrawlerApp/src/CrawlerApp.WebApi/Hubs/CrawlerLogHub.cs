using CrawlerApp.Application.Common.Models.OrderEvent;
using CrawlerApp.Application.Common.Models.Product;
using Microsoft.AspNetCore.SignalR;

namespace CrawlerApp.WebApi.Hubs
{
    public class CrawlerLogHub : Hub
    {
        public async Task SendLogNotificationAsync(OrderEventDto log)
        {
            await Clients.AllExcept(Context.ConnectionId).SendAsync("NewSeleniumLogAdded", log);
        }

        public async Task GetAllProductsAsync(ProductDto product)
        {
            await Clients.AllExcept(Context.ConnectionId).SendAsync("GetAll", product);
        }

        //public async Task GetDiscountedProductsAsync(ProductDto product)
        //{
        //    await Clients.AllExcept(Context.ConnectionId).SendAsync("GetOnDiscounted", product);
        //}

        //public async Task GetNonDiscountedProductsAsync(ProductDto product)
        //{
        //    await Clients.AllExcept(Context.ConnectionId).SendAsync("GetNonDiscounted", product);
        //}
    }
}
