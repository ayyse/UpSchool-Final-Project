using CrawlerApp.Application.Common.Interfaces;
using CrawlerApp.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerApp.Application.Features.Orders.Commands.SoftDelete
{
    public class OrderSoftDeleteCommandHandler : IRequestHandler<OrderSoftDeleteCommand, Response<int>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public OrderSoftDeleteCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Response<int>> Handle(OrderSoftDeleteCommand request, CancellationToken cancellationToken)
        {
            var order = _applicationDbContext.Orders.FirstOrDefault(x => x.Id == request.Id);

            if (order is null)
                throw new InvalidOperationException("The address was not found");

            order.IsDeleted = true;

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return new Response<int>("The order was successfully soft deleted.");
        }
    }
}
