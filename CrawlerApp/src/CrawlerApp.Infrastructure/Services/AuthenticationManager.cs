using CrawlerApp.Application.Common.Interfaces;
using CrawlerApp.Application.Common.Models.Auth;
using Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace CrawlerApp.Infrastructure.Services
{
    public class AuthenticationManager : IAuthenticationService
    {
        // UserManager Identity içinden geliyor
        private readonly UserManager<User> _userManager;

        public AuthenticationManager(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> CreateUserAsync(CreateUserDto createUserDto, CancellationToken cancellationToken)
        {
            var user = createUserDto.MapToUser(); 

            var identityResult = await _userManager.CreateAsync(user, createUserDto.Password);

            if (!identityResult.Succeeded)
            {
                // ValidationFailure
            }

            return user.Id;
        }

        public async Task<string> GenerateEmailActivationTokenAsync(string userId, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(userId);

            return await _userManager.GenerateEmailConfirmationTokenAsync(user);
        }
    }
}
