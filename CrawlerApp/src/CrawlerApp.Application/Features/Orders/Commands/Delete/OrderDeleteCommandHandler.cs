using CrawlerApp.Application.Common.Interfaces;
using CrawlerApp.Domain.Common;
using MediatR;

namespace CrawlerApp.Application.Features.Orders.Commands.Delete
{
    public class OrderDeleteCommandHandler : IRequestHandler<OrderDeleteCommand, Response<int>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public OrderDeleteCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Response<int>> Handle(OrderDeleteCommand request, CancellationToken cancellationToken)
        {
            var order = _applicationDbContext.Orders.FirstOrDefault(x => x.Id == request.Id);

            if (order is null)
                throw new InvalidOperationException("The order was not found");

            _applicationDbContext.Orders.Remove(order);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return new Response<int>("The order was successfully removed.");
        }
    }
}
