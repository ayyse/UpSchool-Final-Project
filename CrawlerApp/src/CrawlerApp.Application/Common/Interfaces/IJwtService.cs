using CrawlerApp.Application.Common.Models.Auth;

namespace CrawlerApp.Application.Common.Interfaces
{
    public interface IJwtService
    {
        JwtDto Generate(string userId, string email, string firstName, string lastName, List<string>? claims = null);
    }
}
