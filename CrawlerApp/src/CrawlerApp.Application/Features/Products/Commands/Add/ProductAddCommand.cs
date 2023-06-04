using CrawlerApp.Domain.Common;
using MediatR;

namespace CrawlerApp.Application.Features.Products.Commands.Add
{
    public class ProductAddCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public bool IsOnSale { get; set; }
        public decimal Price { get; set; }
        public decimal? SalePrice { get; set; }
        public Guid OrderId { get; set; }

        //public ProductAddCommand(string name)
        //{
        //    Id = Guid.NewGuid();
        //    Name = name;
        //}
    }
}
