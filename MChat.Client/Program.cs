using MChat.Client.HttpClients;
using MChat.Client.Services.Implementations;
using MChat.Client.Services.Interfaces;
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

            // 1. On ajoute le LocalStorage en premier
            //builder.Services.AddBlazoredLocalStorage();

            // 2. On enregistre le JwtHandler
            //builder.Services.AddScoped<JwtHandler>();

            // 3. On remplace ta configuration HttpClient par celle-ci :
            // Elle fait exactement la même chose mais AJOUTE le Handler
            builder.Services.AddHttpClient<MChatHttpClient>("MChat-API", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7042/api/v1/");
                client.Timeout = TimeSpan.FromSeconds(5);
            });
            //.AddHttpMessageHandler<JwtHandler>();

            // Cette ligne permet à tes services d'injecter 'HttpClient' normalement
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("MChat-API"));

            // 4. Tes services (ils recevront le HttpClient configuré juste au-dessus)
            builder.Services.AddScoped<IAuthService, AuthService>();
            //builder.Services.AddScoped<PostService>();
            //builder.Services.AddScoped<UserService>();

            await builder.Build().RunAsync();
        }
    }
}
