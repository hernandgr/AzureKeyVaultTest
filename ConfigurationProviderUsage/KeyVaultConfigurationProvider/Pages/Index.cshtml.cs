using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace KeyVaultConfigurationProvider.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration configuration;
        public IndexModel(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string MySecretValue { get; private set; }

        public void OnGet()
        {
            MySecretValue = configuration["password"];
        }
    }
}
