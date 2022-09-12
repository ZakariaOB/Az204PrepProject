using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Web;
using System.Net.Http.Headers;

namespace AuthApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ITokenAcquisition _tokenAcquisition;
        public string content;

        public IndexModel(ILogger<IndexModel> logger, ITokenAcquisition tokenAcquisition)
        {
            _logger = logger;
            _tokenAcquisition = tokenAcquisition;

        }

        public async Task OnGet()
        {
            string[] scope = new string[] { "api://f5ac8984-c651-4a1b-abdf-d09e9b8857a8/Product.Read" };
            string accessToken= await _tokenAcquisition.GetAccessTokenForUserAsync(scope);
            // Not able to get the token here

            string apiURL = "https://productapiv1987.azurewebsites.net/api/Products";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            HttpResponseMessage responseMessage = await client.GetAsync(apiURL);
            content = await responseMessage.Content.ReadAsStringAsync();
        }
    }
}