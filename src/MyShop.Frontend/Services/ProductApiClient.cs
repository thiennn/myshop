using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MyShop.ViewModels;

namespace MyShop.Frontend.Services
{
    public class ProductApiClient : IProductApiClient
    {
        private readonly HttpClient _client;

        public ProductApiClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<IList<ProductVm>> GetProducts()
        {
            var response = await _client.GetAsync("api/products");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<IList<ProductVm>>();
        }
    }
}
