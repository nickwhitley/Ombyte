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
    internal class Client
    {

        private ClientServices _services;

        public ClientServices Services
        {
            get => _services;
            set => _services = value;
        }

        public Client()
        {
            Services = new ClientServices(); 
        }

        public async Task RunBotAsync()
        {
            Services.Client.Log += ClientLog;

            await RegisterCommandsAsync();
            await Services.Client.LoginAsync(TokenType.Bot, new TokenRetreiver().GetToken());
            await Services.Client.StartAsync();
            await Task.Delay(-1);

        }

        private Task ClientLog(LogMessage arg)
        {
            Console.WriteLine(arg.ToString());
            return Task.CompletedTask;
        }

        public async Task RegisterCommandsAsync()
        {
            Services.Client.MessageReceived += HandleCommandAsync;
            Services.Commands.CommandExecuted += OnCommandExecutedAsync;
            
            await Services.Commands.AddModulesAsync(assembly: Assembly.GetEntryAssembly(),
                                                    services: Services as IServiceProvider);
        }

        private async Task HandleCommandAsync(SocketMessage arg)
        {

            var message = arg as SocketUserMessage;
            var context = new SocketCommandContext(Services.Client, message);
            int argPos = 0;

            if (IsCommandSenderValid(message, ref argPos))
            {
                var result = await Services.Commands.ExecuteAsync(
                    context: context,
                    argPos: argPos,
                    services: Services as IServiceProvider);

                if (!result.IsSuccess) Console.WriteLine(result.ErrorReason);
            }
        }

        private bool IsCommandSenderValid(SocketUserMessage message, ref int argPos)
        {
            if (message == null) return false;
            if (message.Author.IsBot) return false;
            if (message.HasMentionPrefix(Services.Client.CurrentUser, ref argPos)) return false;
            if (message.HasStringPrefix("!", ref argPos)) return true;
            
            return false;
        }

        private async Task OnCommandExecutedAsync(Optional<CommandInfo> command,
                                                    ICommandContext context, IResult result)
        {

            if (!string.IsNullOrEmpty(result?.ErrorReason)) 
                await context.Channel.SendMessageAsync(result.ErrorReason);

            var commandName = command.IsSpecified ? command.Value.Name : "command";

            await ClientLog(new LogMessage(LogSeverity.Info,
                "CommandExectuion",
                $"{ commandName } was executed at { DateTime.UtcNow }"));
        }
    }
}
