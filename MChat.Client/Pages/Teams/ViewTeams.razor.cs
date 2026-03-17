using MChat.Client.Components;
using MChat.Client.Models;
using MChat.Client.Models.TeamChatting;
using MChat.Client.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using System.Net;

namespace MChat.Client.Pages.Teams
{
    public partial class ViewTeams
    {
        private bool DisplayOverlayModal = false;

        private int GroupTeamSelected = 1;

        private TeamChat? TeamChatDropDownMenu = null;

        private TeamChatListingViewModel Model { get; set; } = new TeamChatListingViewModel();

        private NotificationPopup? NotifPopup { get; set; } = null;

        [Inject]
        private NavigationManager NavManager { get; set; }

        [Inject]
        private ITeamChatService _TeamChatService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Model.MyTeams = await _TeamChatService.GetOwnerTeamChatsAsync();
                Model.JoinedTeams = await _TeamChatService.GetJoinedTeamChatsAsync();
            }
            catch (HttpRequestException httpEx)
            {
                string errorMsg = "";
                switch(httpEx.StatusCode)
                {
                    case HttpStatusCode.InternalServerError: errorMsg = "Une erreur est survenue lors de la récupèration des équipes de discussions.";
                        break;
                }

                NotifPopup = new NotificationPopup(errorMsg, NotificationPopup.NotificationPopupType.Danger);
                StateHasChanged();
                return;
            }
        }

        private void UpdateGroupTeam(int group)
        {
            GroupTeamSelected = group;
            StateHasChanged();
        }

        private void OpenTeamDropdownMenu(TeamChat team)
        {
            //close if already open
            if (TeamChatDropDownMenu == team)
                TeamChatDropDownMenu = null;
            else
                TeamChatDropDownMenu = team;
            StateHasChanged();
        }


        //TODO : implement overlayModal
        private void CreateNewTeamOpenModal()
        {
            DisplayOverlayModal = true;
            StateHasChanged();
        }

        //TODO : implement openTeam, editTeam, deleteTeam
        private void OpenTeam(Guid teamId)
        {
            NavManager.NavigateTo($"/team?id={teamId}");
        }

        private void EditTeamOpenModal(TeamChat team)
        {
            DisplayOverlayModal = true;
            StateHasChanged();
            //NavManager.NavigateTo($"/teams/edit/{teamId}");
        }

        private void DeleteTeamOpenModal(TeamChat team)
        {
            DisplayOverlayModal = true;
            StateHasChanged();
            //Console.WriteLine($"Delete team {teamId}");
        }
    }
}
