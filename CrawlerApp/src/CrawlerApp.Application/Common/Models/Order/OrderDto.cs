using CrawlerApp.Application.Common.Models.Product;

namespace CrawlerApp.Application.Common.Models.Order
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public int RequestedAmount { get; set; }
        public int TotalFoundAmount { get; set; }

        public ProductCrawlTypeDto ProductCrawlTypes { get; set; }

        public OrderDto(int requestedAmount, int totalFoundAmount, ProductCrawlTypeDto crawlType)
        {
            RequestedAmount = requestedAmount;
            TotalFoundAmount = totalFoundAmount;
            ProductCrawlTypes = crawlType;
        }
    }
}
