using Discord.Commands;
using Discord;

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

        
    }
}
