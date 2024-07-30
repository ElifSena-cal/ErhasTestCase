using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
	{
		private readonly ICategoryRepository _categoryRepository = categoryRepository;

		public async Task<List<Category>> GetAllAsync()
		{
			return await _categoryRepository.GetAllAsync();
		}
	}
}
