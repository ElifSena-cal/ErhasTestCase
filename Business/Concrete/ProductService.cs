using Business.Abstract;

using DataAccess.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductService(IProductRepository productRepository) : IProductService
    {
        private readonly IProductRepository _productRepository = productRepository;

        public Task<List<Product>> GetAllProducts()
        {
           return _productRepository.GetAllProducts();
        }

        public Task<List<Product>> GetByCategoryIdAsync(Guid categoryId)
        {
            return _productRepository.GetByCategoryIdAsync(categoryId);
        }
    }

}
