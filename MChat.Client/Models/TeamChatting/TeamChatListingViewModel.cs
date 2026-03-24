namespace MChat.Client.Models.TeamChatting
{
    public class TeamChatListingViewModel
    {
        public List<TeamChat> MyTeams { get; set; } = new List<TeamChat>();
        public List<TeamChat> JoinedTeams { get; set; } = new List<TeamChat>();
    }
}
