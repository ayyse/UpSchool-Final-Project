using CrawlerApp.Application.Common.Interfaces;
using CrawlerApp.Domain.Common;
using CrawlerApp.Domain.Entities;
using MediatR;

namespace CrawlerApp.Application.Features.Orders.Commands.Add
{
    public class OrderAddCommandHandler : IRequestHandler<OrderAddCommand, Response<Guid>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public OrderAddCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Response<Guid>> Handle(OrderAddCommand request, CancellationToken cancellationToken)
        {
            var order = new Order()
            {
                Id = request.Id,
                ProductCrawlType = request.ProductCrawlType,
                CreatedOn = DateTimeOffset.Now
                //RequestedAmount = request.RequestedAmount,
                //TotalFoundAmount = request.TotalFoundAmount
            };

            try
            {
                await _applicationDbContext.Orders.AddAsync(order, cancellationToken);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {

                await Console.Out.WriteLineAsync(ex.Message);
            }

            return new Response<Guid>("Eklendi", order.Id);
        }
    }
}
