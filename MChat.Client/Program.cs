using MChat.Client.HttpClients;
using MChat.Client.MessageHandlers;
using MChat.Client.Providers;
using MChat.Client.Services.Implementations;
using MChat.Client.Services.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace MChat.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            #region Application services

            // inject a specific HttpClient for custom services
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("MChat-API"));

            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddLocalStorageServices();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddCascadingAuthenticationState();
            builder.Services.AddSingleton<AuthenticationStateProvider,JwtAuthenticationStateProvider>();

            #endregion

            #region HttpMessageHandlers services

            builder.Services.AddScoped<JwtMessageHandler>();
            #endregion

            #region HttpClient configuration

            // configure the HttpClient with JWT handler
            builder.Services.AddHttpClient<MChatHttpClient>("MChat-API", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7042/api/v1/");
                client.Timeout = TimeSpan.FromSeconds(5);
            })
            .AddHttpMessageHandler<JwtMessageHandler>();
            #endregion

            await builder.Build().RunAsync();
        }
    }
}
