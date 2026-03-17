using Microsoft.AspNetCore.Components;

namespace MChat.Client.Components
{
    public partial class OverlayModal
    {
        [Parameter]
        public bool IsVisible { get; set; } = true;

        [Parameter]
        public EventCallback OnClose { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        private async Task CloseOverlay()
        {
            await OnClose.InvokeAsync();
            IsVisible = false;
        }
    }
}
