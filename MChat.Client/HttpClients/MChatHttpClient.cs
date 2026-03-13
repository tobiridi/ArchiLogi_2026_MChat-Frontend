namespace MChat.Client.HttpClients
{
    public class MChatHttpClient
    {
        public readonly HttpClient _client;

        public MChatHttpClient(HttpClient httpClient)
        {
            _client = httpClient;
        }

        //public async Task TestCall()
        //{
        //    var test = await _httpClient.PostAsync("Authentication", JsonContent.Create(""));
        //    Console.WriteLine(test.StatusCode);
        //    Console.WriteLine(test.ReasonPhrase);
        //}
    }
}
