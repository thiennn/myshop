using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using MyShop.ViewModels;

namespace MyShop.Backend.IntegrationTests
{
    public class BrandApiTests : IClassFixture<TestWebApplicationFactory<Startup>>
    {
        private readonly TestWebApplicationFactory<Startup> _factory;

        public BrandApiTests(TestWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetBrands_Success()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/categories");

            response.EnsureSuccessStatusCode();
            var brands = await response.Content.ReadAsAsync<IEnumerable<BrandVm>>();
            Assert.NotEmpty(brands);
        }

        [Fact]
        public async Task CreateBrand_NoAuthen_ReturnUnauthorized()
        {
            var client = _factory.CreateClient();
            var brand = new BrandCreateRequest { Name = "Test brand unauthenticate" };

            var response = await client.PostAsJsonAsync("api/brands", brand);

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task PostBrand_EmptyName_ReturnBadRequest()
        {
            var client = _factory.CreateAuthenticatedClient();
            var brand = new BrandCreateRequest { Name = "" };

            var response = await client.PostAsJsonAsync("api/brands", brand);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task PostBrand_Authenticated_Success()
        {
            var client = _factory.CreateAuthenticatedClient();

            var brand = new BrandCreateRequest { Name = "Test brand authenticated" };

            var response = await client.PostAsJsonAsync("api/brands", brand);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
    }
}
