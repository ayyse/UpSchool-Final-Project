using CrawlerApp.Domain.Enums;

namespace CrawlerApp.Application.Features.Orders.Queries.GetAll
{
    public class OrderGetAllDto
    {
        public Guid Id { get; set; }
        public ProductCrawlType ProductCrawlType { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? ModifiedOn { get; set; }
    }
}
