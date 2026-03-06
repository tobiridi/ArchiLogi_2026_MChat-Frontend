using MChat.Client.Components;
using MChat.Client.Models;
using MChat.Client.Models.Authentication;
using MChat.Client.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace MChat.Client.Pages.Authentication
{
    public partial class Login
    {
        [SupplyParameterFromForm]
        private LoginForm Model { get; set; } = new LoginForm();

        private NotificationPopup? NotifPopup { get; set; } = null;

        [Inject]
        private NavigationManager NavManager { get; set; }

        [Inject]
        private IAuthService authService { get; set; }

        private async Task ValidateForm()
        {
            User? logUser = null;
            try
            {
                logUser = await authService.LoginAsync(Model);
            }
            catch (Exception ex)
            {
                NotifPopup = new NotificationPopup("Une erreur est survenue lors de la tentative connexion.", NotificationPopup.NotificationPopupType.Danger);
                StateHasChanged();
                return;
            }

            if (logUser is not null)
            {
                if(Model.RememberMe)
                {
                    //TODO: add JWT token
                }
                NavManager.NavigateTo("/");
            }
            else
            {
                NotifPopup = new NotificationPopup("Email et/ou mot de passe incorrect.", NotificationPopup.NotificationPopupType.Danger);
                StateHasChanged();
            }
        }
    }
}
