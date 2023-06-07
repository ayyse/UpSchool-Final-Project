using CrawlerApp.Domain.Common;
using MediatR;

namespace CrawlerApp.Application.Features.Orders.Commands.Delete
{
    public class OrderDeleteCommand : IRequest<Response<int>>
    {
        public Guid Id { get; set; }
    }
}
