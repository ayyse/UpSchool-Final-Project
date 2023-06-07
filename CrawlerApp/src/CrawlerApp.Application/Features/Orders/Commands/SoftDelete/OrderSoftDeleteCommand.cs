using CrawlerApp.Domain.Common;
using MediatR;

namespace CrawlerApp.Application.Features.Orders.Commands.SoftDelete
{
    public class OrderSoftDeleteCommand : IRequest<Response<int>>
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
