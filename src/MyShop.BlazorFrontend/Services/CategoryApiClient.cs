using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MyShop.ViewModels;

namespace MyShop.BlazorFrontend.Services
{
    public class CategoryApiClient : ICategoryApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public CategoryApiClient(HttpClient httpClient, AuthenticationStateProvider authenticationStateProvider)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<IList<CategoryVm>> GetCategories()
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            if (authState.User.Identity.IsAuthenticated)
            {
                var accessToken = authState.User.Claims.FirstOrDefault(c => c.Type == "access_token")?.Value;
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }

            var categories = await _httpClient.GetJsonAsync<IList<CategoryVm>>("https://localhost:44349/api/categories");
            return categories;
        }
    }
}
