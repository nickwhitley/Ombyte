using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Ombyte.BotTools;

namespace Ombyte
{
    class Program
    {
        static void Main(string [] args) => new Bot().RunBotAsync().GetAwaiter().GetResult();

    }
}
