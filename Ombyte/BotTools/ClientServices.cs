using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Ombyte.BotTools.Configs;
using Ombyte.TypeReaders;

namespace Ombyte.BotTools
{
    internal class ClientServices
    {

        private DiscordSocketClient _client;
        private CommandService _commands;
        private TokenRetreiver _tokenRetreiver = new TokenRetreiver();
        private TypeReader _intTypeReader;
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

        public TypeReader IntTypeReader 
        { 
            get => _intTypeReader; 
            private set => _intTypeReader = value; 
        }

        public ClientServices()
        {
            Client = new DiscordSocketClient(config: new ClientConfig());
            Commands = new CommandService(config: new CommandServiceConfig { DefaultRunMode = RunMode.Sync});
            TokenRetreiver = new TokenRetreiver();
            IntTypeReader = new IntTypeReader();

            Commands.AddTypeReader(typeof(int), IntTypeReader);
            
            _services = new ServiceCollection()
                .AddSingleton(Client)
                .AddSingleton(Commands)
                .AddSingleton(TokenRetreiver)
                .BuildServiceProvider();
        }

    }
}
