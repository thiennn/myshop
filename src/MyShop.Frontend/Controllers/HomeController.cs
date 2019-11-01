using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyShop.Frontend.Models;
using MyShop.Frontend.Services;

namespace MyShop.Frontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductApiClient _productApiClient;

        public HomeController(ILogger<HomeController> logger, IProductApiClient productApiClient)
        {
            _logger = logger;
            _productApiClient = productApiClient;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productApiClient.GetProducts();
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
