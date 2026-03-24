using MChat.Client.HttpClients;
using MChat.Client.Models;
using MChat.Client.Services.Interfaces;
using MChat.Client.Services.Responses;
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
            GetJoinedTeamChatResponse? response = await _mchatClient._client.GetFromJsonAsync<GetJoinedTeamChatResponse>("TeamChat/user/joined");
            if (response is null)
                return [];

            List<TeamChat> data = response.Teams;
            return data;
        }

        public async Task<List<TeamChat>> GetOwnerTeamChatsAsync()
        {
            GetOwnerTeamChatResponse? response = await _mchatClient._client.GetFromJsonAsync<GetOwnerTeamChatResponse>("TeamChat/user");
            if (response is null)
                return [];

            List<TeamChat> data = response.Teams;
            return data;
        }
    }
}
