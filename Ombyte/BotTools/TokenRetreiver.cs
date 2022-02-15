using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Azure.Security.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Azure.KeyVault;

namespace Ombyte.BotTools
{
    internal class TokenRetreiver
    {

        public TokenRetreiver()
        {

        }

        public static async Task<string> GetSecret(string secretName, string keyVaultName)
        {
            try
            {
                return (await GetClient())
            }
        }

        public static async Task<string> GetAccessTokenAsync()
        {
            AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider();
            return await azureServiceTokenProvider.GetAccessTokenAsync("https://vault.azure.net");
        }

        private static KeyVaultClient GetClient()
        {
            AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider();
            KeyVaultClient keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
            return keyVaultClient;
        }

        public string GetToken()
        {
            return "<bot token>";
        }
        
            
    }
}
