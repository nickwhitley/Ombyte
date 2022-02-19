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

        AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider();


        public TokenRetreiver()
        {

        }

        public async Task<string> GetSecret(string secretName, string keyVaultName)
        {
            try
            {
                return (await GetClient().GetSecretAsync(@"https://ombytekeyvault.vault.azure.net/", secretName)).Value;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> GetAccessTokenAsync()
        {
            return await azureServiceTokenProvider.GetAccessTokenAsync("https://vault.azure.net");
        }

        private KeyVaultClient GetClient()
        {
            var authenticationCallback = new KeyVaultClient
                .AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback);
            var keyVaultClient = new KeyVaultClient(authenticationCallback);
            
            return keyVaultClient;
        }

        public string GetToken()
        {
            var secretName = "BotToken";
            var keyVaultName = "OmbyteKeyVault";

            return GetSecret(secretName, keyVaultName).GetAwaiter().GetResult();
        }
        
            
    }
}
