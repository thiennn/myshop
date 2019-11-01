using MyShop.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyShop.Frontend.Services
{
    public interface ICategoryApiClient
    {
        Task<IList<CategoryVm>> GetCategories();
    }
}
