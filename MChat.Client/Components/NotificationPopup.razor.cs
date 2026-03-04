using Microsoft.AspNetCore.Components;

namespace MChat.Client.Components
{
    public partial class NotificationPopup
    {
        public enum NotificationPopupType
        {
            Info,
            Success,
            Warning,
            Danger,
        }

        [Parameter]
        public string Message { get; set; } = string.Empty;

        [Parameter]
        public NotificationPopupType NotifType { get; set; } = NotificationPopupType.Info;

        [Parameter]
        public int AutoCloseDelay { get; set; } = 5000;

        protected bool IsVisible { get; set; }

        public NotificationPopup() { }

        public NotificationPopup(string message, NotificationPopupType notifType)
        {
            Message = message;
            NotifType = notifType;
        }

        protected override async Task OnParametersSetAsync()
        {
            if (!string.IsNullOrWhiteSpace(Message))
            {
                IsVisible = true;
                StateHasChanged();

                await Task.Delay(AutoCloseDelay);
                IsVisible = false;
                StateHasChanged();
            }
        }

        protected void Close()
        {
            IsVisible = false;
        }

        protected string BootstrapBackground =>
            NotifType switch
            {
                NotificationPopupType.Success => "text-bg-success",
                NotificationPopupType.Danger => "text-bg-danger",
                NotificationPopupType.Warning => "text-bg-warning",
                _ => "text-bg-info"
            };

        protected string Title =>
            NotifType switch
            {
                NotificationPopupType.Success => "Succès",
                NotificationPopupType.Danger => "Erreur",
                NotificationPopupType.Warning => "Attention",
                _ => "Information"
            };
    }
}
