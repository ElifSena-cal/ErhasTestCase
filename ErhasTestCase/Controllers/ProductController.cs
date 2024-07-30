using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class ProductController(IProductService productService) : Controller
    {
        private readonly IProductService _productService=productService;
        public IActionResult Index()
        {
            return View();
        }
        //GetAll
        public async Task<IActionResult> LoadProducts(Guid? categoryId)
        {
            return ViewComponent("Product", new { categoryId = categoryId });
        }
    }
}