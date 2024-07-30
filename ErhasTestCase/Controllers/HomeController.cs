using Business.Abstract;
using ErhasTestCase.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ErhasTestCase.Controllers
{
    public class HomeController(IProductService productService, ILogger<HomeController> logger) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly IProductService _productService = productService;


        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProducts();
            var firstThreeProducts = products.Take(3).ToList();
            return View(firstThreeProducts);
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
