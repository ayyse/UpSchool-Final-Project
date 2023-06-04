using CrawlerApp.Domain.Common;
using CrawlerApp.Domain.Enums;

namespace CrawlerApp.Domain.Entities
{
    public class Order : EntityBase<Guid>
    {
        //public int? RequestedAmount { get; set; }
        //public int? TotalFoundAmount { get; set; }
        public ProductCrawlType ProductCrawlType { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<OrderEvent> OrderEvents { get; set; }
    }
}
