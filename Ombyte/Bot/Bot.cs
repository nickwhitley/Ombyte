using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Ombyte.Bot;

namespace Ombyte.Bot
{
    internal class Bot
    {

        private BotServices _services;

        public Bot()
        {
            _services = new BotServices(); 
        }

        public async Task RunBotAsync()
        {

        }
    }
}
