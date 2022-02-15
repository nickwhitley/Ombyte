using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Ombyte.BotTools;

namespace Ombyte.BotTools
{
    internal class Bot
    {

        private BotServices _services;

        public BotServices Services
        {
            get => _services;
            set => _services = value;
        }

        public Bot()
        {
            Services = new BotServices(); 
        }

        public async Task RunBotAsync()
        {
            Services.Client.Log += ClientLog;

            await RegisterCommandsAsync();
            await Services.Client.LoginAsync(TokenType.Bot, Services.TokenRetreiver.GetToken());
            await Services.Client.StartAsync();
            await Task.Delay(-1);

        }

        private Task ClientLog(LogMessage arg)
        {
            Console.WriteLine(arg);
            return Task.CompletedTask;
        }

        public async Task RegisterCommandsAsync()
        {
            Services.Client.MessageReceived += HandleCommandAsync;
            await Services.Commands.AddModulesAsync(Assembly.GetEntryAssembly(), Services as IServiceProvider);
        }

        private async Task HandleCommandAsync(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;
            var context = new SocketCommandContext(Services.Client, message);

            if (message.Author.IsBot) return;

            int argPos = 0;
            if (message.HasStringPrefix("!", ref argPos))
            {
                var result = await Services.Commands.ExecuteAsync(context, argPos, Services as IServiceProvider);
                if (!result.IsSuccess) Console.WriteLine(result.ErrorReason);
            }
        }
    }
}
