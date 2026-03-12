using MChat.Client.Components;
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

        private bool IsLoading { get; set; } = false;

        [Inject]
        private NavigationManager NavManager { get; set; }

        [Inject]
        private IAuthService authService { get; set; }

        protected override void OnAfterRender(bool firstRender)
        {
            this.IsLoading = false;
        }

        private async Task ValidateForm()
        {
            bool isLogSuccess = false;
            this.IsLoading = true;
            StateHasChanged();

            try
            {
                isLogSuccess = await authService.LoginAsync(Model);
            }
            catch (Exception ex)
            {
                NotifPopup = new NotificationPopup("Une erreur est survenue lors de la tentative connexion.", NotificationPopup.NotificationPopupType.Danger);
                StateHasChanged();
                return;
            }

            if (isLogSuccess)
            {
                if(Model.RememberMe)
                {
                    //TODO: implement other management of jwt token when RememberMe is activate
                }
                NavManager.NavigateTo("/", true);
            }
            else
            {
                NotifPopup = new NotificationPopup("Email et/ou mot de passe incorrect.", NotificationPopup.NotificationPopupType.Danger);
                StateHasChanged();
            }
        }
    }
}
