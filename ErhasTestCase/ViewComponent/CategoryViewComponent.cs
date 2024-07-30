using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class CategoryViewComponent(ICategoryService categoryService) : ViewComponent
{
	private readonly ICategoryService _categoryService = categoryService;
	public async Task<IViewComponentResult> InvokeAsync()
	{
		var categories = await _categoryService.GetAllAsync();
		return View(categories);
	}
}
