using MChat.Client.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace MChat.Client.Layout
{
    public partial class NavMenu
    {
        [Inject]
        private NavigationManager NavManager { get; set; }

        [Inject]
        private IAuthService authService { get; set; }

        private async Task Logout()
        {
            await authService.Logout();
            NavManager.NavigateTo("/login", true);
        }
    }
}
