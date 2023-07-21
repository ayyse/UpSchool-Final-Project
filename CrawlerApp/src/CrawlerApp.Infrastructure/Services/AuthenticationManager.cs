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
        private readonly SignInManager<User> _signInManager;
        private readonly IJwtService _jwtService;

        public AuthenticationManager(UserManager<User> userManager, SignInManager<User> signInManager, IJwtService jwtService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
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

        public async Task<JwtDto> LoginAsync(AuthLoginRequest authLoginRequest, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(authLoginRequest.Email);

            var loginResult = await _signInManager.PasswordSignInAsync(user, authLoginRequest.Password, false, false);

            // kullanıcının tüm bilgilerini dönmek güvenlik açısından doğru değil.
            return _jwtService.Generate(user.Id, user.Email, user.FirstName, user.LastName);
        }

        public async Task<JwtDto> SocialLoginAsync(string email, string firstName, string lastName, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user is not null)
                return _jwtService.Generate(user.Id, user.Email, user.FirstName, user.LastName);
            var userId = Guid.NewGuid().ToString();

            user = new User()
            {
                Id = userId,
                UserName = email,
                Email = email,
                EmailConfirmed = true,
                FirstName = firstName,
                LastName = lastName,
                CreatedOn = DateTimeOffset.Now,
                CreatedByUserId = userId,
            };

            return _jwtService.Generate(user.Id, user.Email, user.FirstName, user.LastName);
        }
    }
}
