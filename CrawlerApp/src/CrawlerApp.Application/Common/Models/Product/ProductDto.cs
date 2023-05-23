using MediatR;

namespace CrawlerApp.Application.Common.Models.Product
{
    public class ProductDto : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ProductDto(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
