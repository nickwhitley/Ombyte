using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Ombyte.BotTools.Configs;
using Ombyte.Modules.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ombyte.BotTools
{
    internal class ClientServices
    {

        private DiscordSocketClient _client;
        private CommandService _commands;
        private TokenRetreiver _tokenRetreiver = new TokenRetreiver();
        private IServiceProvider _services;

        public DiscordSocketClient Client
        {
            get => _client;
            private set => _client = value;
        }

        public CommandService Commands
        {
            get => _commands;
            private set => _commands = value;
        }

        public TokenRetreiver TokenRetreiver
        {
            get => _tokenRetreiver;
            private set => _tokenRetreiver = value;
        }

        public ClientServices()
        {
            ///TODO does this work or do I use _client to set the value
            Client = new DiscordSocketClient(config: new ClientConfig());
            Commands = new CommandService();
            TokenRetreiver = new TokenRetreiver();
            _services = new ServiceCollection()
                .AddSingleton(Client)
                .AddSingleton(Commands)
                .AddSingleton(TokenRetreiver)
                .BuildServiceProvider();
        }

    }
}
