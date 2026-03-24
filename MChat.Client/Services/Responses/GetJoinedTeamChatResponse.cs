using MChat.Client.Models;

namespace MChat.Client.Services.Responses
{
    public class GetJoinedTeamChatResponse
    {
        public List<TeamChat> Teams { get; set; } = [];
    }
}
