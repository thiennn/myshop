using MyShop.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyShop.Frontend.Services
{
    public interface IProductApiClient
    {
        Task<IList<ProductVm>> GetProducts();
    }
}
