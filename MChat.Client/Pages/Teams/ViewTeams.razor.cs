using MChat.Client.Models;
using MChat.Client.Models.Authentication;
using MChat.Client.Models.TeamChatting;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace MChat.Client.Pages.Teams
{
    public partial class ViewTeams
    {
        [Inject]
        private NavigationManager NavManager { get; set; }

        private bool DisplayOverlayModal = false;

        private int GroupTeamSelected = 1;

        private TeamChat? TeamChatDropDownMenu = null;

        private TeamChatListingViewModel Model { get; set; } = new TeamChatListingViewModel();

        protected override async Task OnInitializedAsync()
        {
            //TODO : get from api
            Model.MyTeams = [
                new TeamChat(Guid.NewGuid(), null, "développement", null),
                new TeamChat(Guid.NewGuid(), null, "study", null),
                new TeamChat(Guid.NewGuid(), null, "amis", null),
            ];

            Model.JoinedTeams = [];
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

        private void EditTeam(TeamChat team)
        {
            DisplayOverlayModal = true;
            StateHasChanged();
            //NavManager.NavigateTo($"/teams/edit/{teamId}");
        }

        private void DeleteTeam(TeamChat team)
        {
            DisplayOverlayModal = true;
            StateHasChanged();
            //Console.WriteLine($"Delete team {teamId}");
        }
    }
}
