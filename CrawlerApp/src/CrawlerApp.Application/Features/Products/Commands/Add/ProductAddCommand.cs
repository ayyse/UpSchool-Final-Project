using MediatR;

namespace CrawlerApp.Application.Features.Products.Commands.Add
{
    public class ProductAddCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ProductAddCommand(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
