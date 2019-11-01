using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using MyShop.ViewModels;

namespace MyShop.Frontend.Services
{
    public class ProductApiClient : IProductApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductApiClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IList<ProductVm>> GetProducts()
        {
            var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client.GetAsync("https://localhost:44349/api/products");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<IList<ProductVm>>();
        }
    }
}
