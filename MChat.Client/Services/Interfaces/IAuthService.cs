using MChat.Client.Models.Authentication;

namespace MChat.Client.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(RegisterForm form);
    }
}
