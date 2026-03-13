using MChat.Client.HttpClients;
using MChat.Client.Models.Authentication;
using MChat.Client.Services.Interfaces;
using MChat.Client.Services.Responses;
using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace MChat.Client.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly MChatHttpClient _mchatClient;
        private readonly ILocalStorageService _localStorage;
        
        public AuthService(MChatHttpClient httpClient, ILocalStorageService localStorage)
        {
            _mchatClient = httpClient;
            _localStorage = localStorage;
        }

        public async Task<bool> LoginAsync(LoginForm form)
        {
            var request = await _mchatClient._client.PostAsJsonAsync<LoginForm>("Authentication/login", form);
            if(!request.IsSuccessStatusCode)
                return false;

            AuthResponse? response = await request.Content.ReadFromJsonAsync<AuthResponse>();
            if (response is null)
                return false;

            //TODO : maybe update the implementation with "remember me" UI element
            _localStorage.SetItem<string>(IAuthService.ACCESS_TOKEN_KEY, response.AccessToken);
            _localStorage.SetItem<string>(IAuthService.REFRESH_TOKEN_KEY, response.RefreshToken);

            return true;
        }

        public async Task Logout()
        {
            var request = await _mchatClient._client.DeleteAsync("Authentication/logout");

            if(request.IsSuccessStatusCode)
            {
                _localStorage.RemoveItem(IAuthService.ACCESS_TOKEN_KEY);
                _localStorage.RemoveItem(IAuthService.REFRESH_TOKEN_KEY);
            }
        }

        public async Task<bool> RegisterAsync(RegisterForm form)
        {
            var request = await _mchatClient._client.PostAsJsonAsync<RegisterForm>("Authentication/register", form);
            return request.IsSuccessStatusCode;
        }
    }
}
