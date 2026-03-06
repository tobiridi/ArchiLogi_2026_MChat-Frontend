using MChat.Client.Components;
using MChat.Client.HttpClients;
using MChat.Client.Models;
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
        private IAuthService authService { get; set; }

        private async Task ValidateForm()
        {
            bool isRegister = await authService.RegisterAsync(Model);
            if (isRegister)
            {
                Model = new RegisterForm();
                NotifPopup = new NotificationPopup("Compte créer avec succès.", NotificationPopup.NotificationPopupType.Success);
                StateHasChanged();
            }
            else
            {
                NotifPopup = new NotificationPopup("Une erreur est survenue lors de la création du compte.", NotificationPopup.NotificationPopupType.Danger);
                StateHasChanged();
            }
        }
    }
}
