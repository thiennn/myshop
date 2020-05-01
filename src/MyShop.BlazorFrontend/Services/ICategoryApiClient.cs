using System.Collections.Generic;
using System.Threading.Tasks;
using MyShop.ViewModels;

namespace MyShop.BlazorFrontend.Services
{
    public interface ICategoryApiClient
    {
        Task<IList<CategoryVm>> GetCategories();
    }
}
