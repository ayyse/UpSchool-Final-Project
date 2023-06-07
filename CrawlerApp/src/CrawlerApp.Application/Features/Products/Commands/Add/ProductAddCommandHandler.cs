using CrawlerApp.Application.Common.Interfaces;
using CrawlerApp.Application.Common.Models.Product;
using CrawlerApp.Domain.Common;
using CrawlerApp.Domain.Entities;
using MediatR;

namespace CrawlerApp.Application.Features.Products.Commands.Add
{
    public class ProductAddCommandHandler : IRequestHandler<ProductAddCommand, Response<Guid>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IProductHubService _productHubService;

        public ProductAddCommandHandler(IApplicationDbContext applicationDbContext, IProductHubService productHubService)
        {
            _applicationDbContext = applicationDbContext;
            _productHubService = productHubService;
        }

        public async Task<Response<Guid>> Handle(ProductAddCommand request, CancellationToken cancellationToken)
        {
            var product = new Product()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Picture = request.Picture,
                IsOnSale = request.IsOnSale,
                Price = request.Price,
                SalePrice = request.SalePrice,
                OrderId = request.OrderId,
                CreatedOn = DateTimeOffset.Now
            };

            try
            {
                await _applicationDbContext.Products.AddAsync(product, cancellationToken);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                // Hata durumunda uygun bir yanıt döndürebilir veya loglayabilirsiniz.
                Console.WriteLine(ex.Message +  "Veritabanına ekleme işlemi başarısız oldu.");
            }

            await _productHubService.AddProductAsync(MapCommandToDto(request), cancellationToken);

            return new Response<Guid>("Eklendi", product.Id);
        }

        private ProductDto MapCommandToDto(ProductAddCommand command)
        {
            return new ProductDto()
            {
                Name = command.Name,
                Picture = command.Picture,
                Price = command.Price,
                SalePrice = command.SalePrice
            };
        }
    }
}
