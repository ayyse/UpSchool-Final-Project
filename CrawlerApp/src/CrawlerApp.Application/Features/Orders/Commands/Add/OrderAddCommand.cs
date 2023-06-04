using CrawlerApp.Domain.Common;
using CrawlerApp.Domain.Enums;
using MediatR;

namespace CrawlerApp.Application.Features.Orders.Commands.Add
{
    public class OrderAddCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        //public int? RequestedAmount { get; set; }
        //public int? TotalFoundAmount { get; set; }
        public ProductCrawlType ProductCrawlType { get; set; }
    }
}
