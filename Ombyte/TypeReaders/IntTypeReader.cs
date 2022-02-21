using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ombyte.TypeReaders
{
    internal class IntTypeReader : TypeReader
    {
        public override Task<TypeReaderResult> ReadAsync(ICommandContext context,
            string input, IServiceProvider services)
        {
            int result;
            if(int.TryParse(input, out result))
            {
                return Task.FromResult(TypeReaderResult.FromSuccess(result));
            }

            return Task.FromResult(TypeReaderResult.
                FromError(CommandError.ParseFailed, "Input could not be parsed to an int"));
        }
    }
}
