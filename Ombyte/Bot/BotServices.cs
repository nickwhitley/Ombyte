using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ombyte.Bot
{
    internal class BotServices
    {

        private DiscordSocketClient _client;
        private CommandService _commands;
        private TokenRetreiver _tokenRetreiver;
        private IServiceProvider _services;

        public BotServices()
        {
            _client = new DiscordSocketClient();
            _commands = new CommandService();
            _tokenRetreiver = new TokenRetreiver();
            _services = new ServiceCollection()
                .AddSingleton(_client)
                .AddSingleton(_commands)
                .AddSingleton(_tokenRetreiver)
                .BuildServiceProvider();
        }

    }
}
