using CrawlerApp.Application.Common.Interfaces;
using CrawlerApp.Domain.Common;
using CrawlerApp.Domain.Entities;
using MediatR;

namespace CrawlerApp.Application.Features.OrderEvents.Commands.Add
{
    public class OrderEventAddCommandHandler : IRequestHandler<OrderEventAddCommand, Response<Guid>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public OrderEventAddCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Response<Guid>> Handle(OrderEventAddCommand request, CancellationToken cancellationToken)
        {
            var orderEvent = new OrderEvent()
            {
                Id = Guid.NewGuid(),
                OrderId = request.OrderId,
                Status = request.Status,
                CreatedOn = DateTimeOffset.Now
            };

            try
            {
                await _applicationDbContext.OrderEvents.AddAsync(orderEvent, cancellationToken);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {

                await Console.Out.WriteLineAsync(ex.Message);
            }

            return new Response<Guid>("Eklendi", orderEvent.Id);
        }
    }
}
