using MChat.Client.Components;
using MChat.Client.Models.Authentication;
using MChat.Client.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace MChat.Client.Pages.Authentication
{
    public partial class Register
    {
        [SupplyParameterFromForm]
        private RegisterForm Model { get; set; } = new RegisterForm();

        private NotificationPopup? NotifPopup { get; set; } = null;

        [Inject]
        private NavigationManager NavManager { get; set; }

        private bool IsLoading { get; set; } = false;

        [Inject]
        private IAuthService authService { get; set; }

        protected override void OnAfterRender(bool firstRender)
        {
            this.IsLoading = false;
        }

        private async Task ValidateForm()
        {
            this.IsLoading = true;
            bool isRegister = false;
            StateHasChanged();

            try
            {
                isRegister = await authService.RegisterAsync(Model);
            }
            catch (Exception)
            {
                NotifPopup = new NotificationPopup("Une erreur est survenue lors de la tentative d'inscription.", NotificationPopup.NotificationPopupType.Danger);
                StateHasChanged();
                return;
            }

            if (isRegister)
            {
                Model = new RegisterForm();
                NotifPopup = new NotificationPopup("Compte créer avec succès.", NotificationPopup.NotificationPopupType.Success);
            }
            else
            {
                NotifPopup = new NotificationPopup("Une erreur est survenue lors de la création du compte.", NotificationPopup.NotificationPopupType.Danger);
            }

            StateHasChanged();
            if (isRegister)
            {
                await Task.Delay(1500);
                NavManager.NavigateTo("/login");
            }
        }
    }
}
