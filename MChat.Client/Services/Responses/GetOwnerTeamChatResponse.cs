using MChat.Client.Models;

namespace MChat.Client.Services.Responses
{
    public class GetOwnerTeamChatResponse
    {
        public List<TeamChat> Teams { get; set; } = [];
        public User Creator { get; set; }
    }
}
