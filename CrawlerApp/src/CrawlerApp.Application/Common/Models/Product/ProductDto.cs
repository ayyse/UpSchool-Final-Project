using MediatR;

namespace CrawlerApp.Application.Common.Models.Product
{
    public class ProductDto : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public decimal Price { get; set; }
        public decimal? SalePrice { get; set; }

        public ProductDto()
        {
            
        }

        public ProductDto(string name, string picture, decimal price, decimal salePrice)
        {
            Id = Guid.NewGuid();
            Name = name;
            Picture = picture;
            Price = price;
            SalePrice = salePrice;
        }
    }
}
