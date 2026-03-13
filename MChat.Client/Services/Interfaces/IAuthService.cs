using MChat.Client.Models.Authentication;

namespace MChat.Client.Services.Interfaces
{
    public interface IAuthService
    {
        public const string ACCESS_TOKEN_KEY = "access_token";
        public const string REFRESH_TOKEN_KEY = "refresh_token";

        Task<bool> RegisterAsync(RegisterForm form);
        Task<bool> LoginAsync(LoginForm form);
        Task Logout();
    }
}
