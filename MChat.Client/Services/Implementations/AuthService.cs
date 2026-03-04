using MChat.Client.HttpClients;
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

        public async Task<bool> RegisterAsync(RegisterForm form)
        {
            var request = await _mchatClient._client.PostAsJsonAsync<RegisterForm>("Authentication", form);
            return request.IsSuccessStatusCode;
        }
    }
}
