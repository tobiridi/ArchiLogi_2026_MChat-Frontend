using MChat.Client.HttpClients;
using MChat.Client.Models;
using MChat.Client.Services.Interfaces;
using System.Net.Http.Json;

namespace MChat.Client.Services.Implementations
{
    public class TeamChatService : ITeamChatService
    {
        private readonly MChatHttpClient _mchatClient;

        public TeamChatService(MChatHttpClient mchatClient)
        {
            _mchatClient = mchatClient;
        }

        public async Task<List<TeamChat>> GetJoinedTeamChatsAsync()
        {
            List<TeamChat>? data = await _mchatClient._client.GetFromJsonAsync<List<TeamChat>>($"TeamChat/user/joined");
            return data ?? [];
        }

        public async Task<List<TeamChat>> GetOwnerTeamChatsAsync()
        {
            List<TeamChat>? data = await _mchatClient._client.GetFromJsonAsync<List<TeamChat>>($"TeamChat/user");
            return data ?? [];
        }
    }
}
