using Discord.Commands;
using Discord;
using Discord.WebSocket;
using Ombyte.BotTools;

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

        [Command("nsfwtest")]
        [Summary("Used for testing nsfw attribute.")]
        [RequireNsfw]
        public async Task NsfwTest()
            => await ReplyAsync("NSFW");

        [Command("kick")]
        [Summary("Kick's user, admin only. Currently responds with 403: forbidden.")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task KickAsync(string username)
        {
            var user = Context.Guild.GetUser(Context.User.Id);

            await user.KickAsync();
            await Context.Channel.SendMessageAsync($":eye: { user.Username } has been kicked.");
        }
            
        
    }
}
