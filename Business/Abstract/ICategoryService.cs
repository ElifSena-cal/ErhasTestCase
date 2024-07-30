using Entities;

namespace Business.Abstract
{
	public interface ICategoryService
	{
		Task<List<Category>> GetAllAsync();
	}
}
