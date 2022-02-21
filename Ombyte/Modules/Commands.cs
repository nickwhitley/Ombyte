using Discord.Commands;
using Discord;
using Discord.WebSocket;

namespace Ombyte.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        [Command("ping")]
        [Summary("Used for testing, should reply pong.")]
        public async Task Ping()
        {
            await ReplyAsync("pong");
        }

        [Command("say")]
        [Summary("Used for testing, should echo parameter.")]
        public async Task SayAsync([Remainder] string echoText)
            => await ReplyAsync(echoText);

        [Command("alluserinfo")]
        [Summary("Used for testing, should print defined user info for online users.")]
        public async Task AllUserInfoAsync()
        {
            
            foreach (var user in Context.Guild.Users)
            {
                await ReplyAsync($"{ user.Username}#{ user.Discriminator }");
            }
        }
    }
}
