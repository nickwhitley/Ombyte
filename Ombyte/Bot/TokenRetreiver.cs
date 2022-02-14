using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace Ombyte.Bot
{
    internal class TokenRetreiver
    {

        SecretClient _secretClient;

        public TokenRetreiver()
        {
            ///TODO store these values in a configuration file (appsettings.json).
            _secretClient = new SecretClient(
                new Uri("https://ombytekeyvault.vault.azure.net/"),
                new DefaultAzureCredential());
        }
        
            
    }
}
