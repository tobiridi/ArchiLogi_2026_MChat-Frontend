using MChat.Client.Services.Implementations;
using MChat.Client.Services.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MChat.Client.Providers
{
    public class JwtAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;

        public JwtAuthenticationStateProvider(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string? accessToken = _localStorage.GetItem<string>(IAuthService.ACCESS_TOKEN_KEY);
            if (string.IsNullOrEmpty(accessToken))
            {
                AuthenticationState authState = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
                return Task.FromResult(authState);
            }

            //retrieve data from jwt token
            JwtSecurityToken jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(accessToken);
            ClaimsIdentity identity;
            if (jwtToken.ValidTo > DateTime.UtcNow)
                identity = new ClaimsIdentity(jwtToken.Claims, "jwt");
            else
                identity = new ClaimsIdentity();

            ClaimsPrincipal user = new ClaimsPrincipal(identity);
            return Task.FromResult(new AuthenticationState(user));
        }
    }
}
