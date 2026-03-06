using MChat.Client.HttpClients;
using MChat.Client.Models;
using MChat.Client.Models.Authentication;
using MChat.Client.Services.Interfaces;
using System.Net.Http.Json;

namespace MChat.Client.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly MChatHttpClient _mchatClient;

        public AuthService(MChatHttpClient httpClient)
        {
            _mchatClient = httpClient;
        }

        public async Task<User?> LoginAsync(LoginForm form)
        {
            var request = await _mchatClient._client.PostAsJsonAsync<LoginForm>("Authentication/login", form);
            if(request.IsSuccessStatusCode)
            {
                return await request.Content.ReadFromJsonAsync<User>();
            }
            return null;
        }

        public async Task<bool> RegisterAsync(RegisterForm form)
        {
            var request = await _mchatClient._client.PostAsJsonAsync<RegisterForm>("Authentication/register", form);
            return request.IsSuccessStatusCode;
        }
    }
}
