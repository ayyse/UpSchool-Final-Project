using CrawlerApp.Application.Common.Interfaces;
using CrawlerApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CrawlerApp.Application.Features.Orders.Queries.GetAll
{
    public class OrderGetAllQueryHandler : IRequestHandler<OrderGetAllQuery, List<OrderGetAllDto>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public OrderGetAllQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<OrderGetAllDto>> Handle(OrderGetAllQuery request, CancellationToken cancellationToken)
        {
            var dbQuery = _applicationDbContext.Orders.AsQueryable();

            //dbQuery = dbQuery.Where(x => x.CreatedByUserId == request.CreatedByUserId);

            //if (request.IsDeleted.HasValue) dbQuery = dbQuery.Where(x => x.IsDeleted == request.IsDeleted.Value);

            var orders = await dbQuery
                .Select(x => MapToDto(x))
                .ToListAsync(cancellationToken);

            return orders.ToList();
        }

        private static OrderGetAllDto MapToDto(Order order)
        {
            return new OrderGetAllDto()
            {
                Id = order.Id,
                ProductCrawlType = order.ProductCrawlType,
                CreatedOn = order.CreatedOn,
                ModifiedOn = order.ModifiedOn
            };
        }
    }
}
