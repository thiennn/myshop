using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyShop.Frontend.Services;

namespace MyShop.Frontend.Components
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        private readonly ICategoryApiClient _categoryApiClient;

        public CategoryMenuViewComponent(ICategoryApiClient categoryApiClient)
        {
            _categoryApiClient = categoryApiClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryApiClient.GetCategories();
            return View(categories);
        }
    }
}
