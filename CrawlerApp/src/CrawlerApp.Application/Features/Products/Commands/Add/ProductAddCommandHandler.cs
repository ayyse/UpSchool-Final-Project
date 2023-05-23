using CrawlerApp.Application.Common.Interfaces;
using CrawlerApp.Application.Common.Models.Crawler;
using CrawlerApp.Application.Common.Models.Product;
using MediatR;

namespace CrawlerApp.Application.Features.Products.Commands.Add
{
    public class ProductAddCommandHandler //: IRequestHandler<ProductDto, Guid>
    {
        //private readonly IHubContext<CrawlerLogHub> _hubContext;

        //public AccountHubManager(IHubContext<AccountHub> hubContext)
        //{
        //    _hubContext = hubContext;
        //}

        //public async Task<Guid> Handle(ProductDto request, CancellationToken cancellationToken)
        //{
        //    await _accountHubService.AddProductAsync(request, cancellationToken);

        //    return request.Id;
        //}
    }
}
