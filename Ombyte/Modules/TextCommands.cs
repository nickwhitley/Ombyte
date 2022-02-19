using Discord.Commands;
using Discord;

namespace Ombyte.Modules
{
    public class TextCommands : ModuleBase<SocketCommandContext>
    {
        [Command("ping")]
        public async Task Ping()
        {
            await ReplyAsync("pong");
        }

        [Command("say hi to Nick")]
        public async Task SayHiToNick()
        {
            await ReplyAsync("'Sup faggot");
        }

        [Command("say sorry to Nick")]
        public async Task SaySorryToNick()
        {
            await ReplyAsync("Sorry faggot");
        }

        [Command("hlep")]
        public async Task Hlep()
        {
            await ReplyAsync("You have to spell it like Nick spells it..");
        }
    }
}
