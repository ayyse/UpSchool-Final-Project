using CrawlerApp.Application.Common.Models.Auth;
using CrawlerApp.Application.Features.Auth.Commands.Login;

namespace CrawlerApp.Application.Common.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> CreateUserAsync(CreateUserDto createUserDto, CancellationToken cancellationToken);
        Task<string> GenerateEmailActivationTokenAsync(string userId, CancellationToken cancellationToken);
        Task<JwtDto> LoginAsync(AuthLoginRequest authLoginRequest, CancellationToken cancellationToken);
        Task<JwtDto> SocialLoginAsync(string email, string firstName, string lastName, CancellationToken cancellationToken);
    }
}
