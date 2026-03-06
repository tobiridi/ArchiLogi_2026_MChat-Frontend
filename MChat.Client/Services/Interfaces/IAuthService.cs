using MChat.Client.Models;
using MChat.Client.Models.Authentication;

namespace MChat.Client.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(RegisterForm form);
        Task<User?> LoginAsync(LoginForm form);
    }
}
