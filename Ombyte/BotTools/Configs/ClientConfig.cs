using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace Ombyte.BotTools.Configs
{
    internal class ClientConfig : DiscordSocketConfig
    {
        new readonly GatewayIntents GatewayIntents = GatewayIntents.AllUnprivileged;
    }
}
