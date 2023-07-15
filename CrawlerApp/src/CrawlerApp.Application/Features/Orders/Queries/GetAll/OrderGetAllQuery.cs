using MediatR;

namespace CrawlerApp.Application.Features.Orders.Queries.GetAll
{
    public class OrderGetAllQuery : IRequest<List<OrderGetAllDto>>
    {
        public string? CreatedByUserId { get; set; }
        public bool? IsDeleted { get; set; }

        public OrderGetAllQuery(string? createdByUserId, bool? isDeleted)
        {
            CreatedByUserId = createdByUserId;

            IsDeleted = isDeleted;
        }
    }
}
