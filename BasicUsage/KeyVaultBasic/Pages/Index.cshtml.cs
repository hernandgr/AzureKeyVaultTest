using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;

namespace KeyVaultBasic.Pages
{
    public class IndexModel : PageModel
    {
        public string MySecretValue { get; private set; }

        public async Task OnGetAsync()
        {
            string url = "https://thetestvault.vault.azure.net/secrets/password";

            var azureServiceTokenProvider = new AzureServiceTokenProvider();
            var keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
            var secret = await keyVaultClient.GetSecretAsync(url).ConfigureAwait(false);

            MySecretValue = secret.Value;
        }
    }
}
