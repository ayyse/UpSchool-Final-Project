using CrawlerApp.Domain.Common;
using MediatR;

namespace CrawlerApp.Application.Features.Auth.Commands.Login
{
    public class AuthLoginCommand : IRequest<Response<AuthLoginDto>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
