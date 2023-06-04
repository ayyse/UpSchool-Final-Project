using CrawlerApp.Domain.Common;
using CrawlerApp.Domain.Enums;
using MediatR;

namespace CrawlerApp.Application.Features.OrderEvents.Commands.Add
{
    public class OrderEventAddCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public OrderStatus Status { get; set; }
    }
}
