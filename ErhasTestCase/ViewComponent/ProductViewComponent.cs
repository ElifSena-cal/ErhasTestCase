using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class ProductViewComponent(IProductService productService) : ViewComponent
{
	private readonly IProductService _productService = productService;
    public async Task<IViewComponentResult> InvokeAsync(Guid? CategoryId)
    {
        List<Product> filteredProducts;
        if (CategoryId.HasValue)
        {
            filteredProducts = await _productService.GetByCategoryIdAsync(CategoryId.Value);
        }
        else
        {
            filteredProducts = await _productService.GetAllProducts();
        }
        return View(filteredProducts);
    }

}
