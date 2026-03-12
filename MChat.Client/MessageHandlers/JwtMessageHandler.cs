using MChat.Client.Services.Interfaces;
using Microsoft.JSInterop;
using System.Net.Http.Headers;

namespace MChat.Client.MessageHandlers
{
    public class JwtMessageHandler : DelegatingHandler
    {
        private readonly ILocalStorageService _localStorage;

        public JwtMessageHandler(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string? accessToken = _localStorage.GetItem<string>(IAuthService.ACCESS_TOKEN_KEY);

            if (!string.IsNullOrEmpty(accessToken))
            {
                request.Headers.Authorization =
                    new AuthenticationHeaderValue("Bearer", accessToken);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
