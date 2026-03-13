using MChat.Client.Components;
using MChat.Client.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace MChat.Client.Layout
{
    public partial class NavMenu
    {
        [Inject]
        private NavigationManager NavManager { get; set; }

        private NotificationPopup? NotifPopup { get; set; } = null;

        [Inject]
        private IAuthService authService { get; set; }

        private async Task Logout()
        {
            try
            {
                await authService.Logout();
                NavManager.NavigateTo("/login", true);
            }
            catch (Exception)
            {
                NotifPopup = new NotificationPopup("Une erreur est survenue lors de la tentative déconnexion.", NotificationPopup.NotificationPopupType.Danger);
                StateHasChanged();
            }
        }
    }
}
