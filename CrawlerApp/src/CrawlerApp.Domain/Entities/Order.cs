using CrawlerApp.Domain.Common;

namespace CrawlerApp.Domain.Entities
{
    public class Order : EntityBase<Guid>
    {
        public int RequestedAmount { get; set; }
        public int TotalFoundAmount { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
