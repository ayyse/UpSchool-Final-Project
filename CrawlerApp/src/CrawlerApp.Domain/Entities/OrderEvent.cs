using CrawlerApp.Domain.Common;
using CrawlerApp.Domain.Enums;

namespace CrawlerApp.Domain.Entities
{
    public class OrderEvent : EntityBase<Guid>
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; }

        public OrderStatus Status { get; set; }
    }
}
