using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MyShop.ViewModels;

namespace MyShop.Frontend.Services
{
    public class CategoryApiClient : ICategoryApiClient
    {
        private readonly HttpClient _client;

        public CategoryApiClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<IList<CategoryVm>> GetCategories()
        {
            var response = await _client.GetAsync("api/categories");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<IList<CategoryVm>>();
        }
    }
}
