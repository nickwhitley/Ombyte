using Discord.WebSocket;

namespace OmbyteBot
{
    class Program
    {
        public static void Main(string[] args) =>
            new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            var _client = new DiscordSocketClient();
            _client.Log += Log;
        }
    }
}