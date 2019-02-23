using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;

namespace KeyVaultTest01.Pages
{
    public class IndexModel : PageModel
    {
        public string MySecretValue { get; set; }

        public async Task OnGetAsync()
        {
            var azureServiceTokenProvider = new AzureServiceTokenProvider();
            var keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
            var secret = await keyVaultClient.GetSecretAsync("https://thetestvault.vault.azure.net/secrets/password").ConfigureAwait(false);

            MySecretValue = secret.Value;
        }
    }
}
