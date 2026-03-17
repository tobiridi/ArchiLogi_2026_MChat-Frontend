using MChat.Client.Models;

namespace MChat.Client.Services.Interfaces
{
    public interface ITeamChatService
    {
        public Task<List<TeamChat>> GetOwnerTeamChatsAsync();
        public Task<List<TeamChat>> GetJoinedTeamChatsAsync();
    }
}
