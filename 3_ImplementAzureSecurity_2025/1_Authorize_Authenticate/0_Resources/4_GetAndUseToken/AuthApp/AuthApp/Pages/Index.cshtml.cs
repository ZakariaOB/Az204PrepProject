using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Web;

namespace AuthApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ITokenAcquisition _tokenAcquisition;
        public string blobContent;

        public IndexModel(ILogger<IndexModel> logger, ITokenAcquisition tokenAcquisition)
        {
            _logger = logger;
            _tokenAcquisition = tokenAcquisition;

        }

        public async Task OnGet()
        {
            /* If we need to get the access the token 
             * string[] scope = new string[] { "https://storage.azure.com/user_impersonation" };
             * accessToken = await _tokenAcquisition.GetAccessTokenForUserAsync(scope);
            */


            // In case the token acquisition and processing will be behind the scenes
            TokenAcquisitionTokenCredential tokenAcquisitionTokenCredential = new (_tokenAcquisition);

            Uri blobUri = new ("https://azstore5.blob.core.windows.net/data/ScriptOne.sql");
            BlobClient blobClient = new (blobUri, tokenAcquisitionTokenCredential);

            MemoryStream ms = new ();
            blobClient.DownloadTo(ms);
            ms.Position = 0;

            StreamReader sr = new (ms);
            blobContent = sr.ReadToEnd();
        }
    }
}