using System.Collections.Generic;
using System.IO;
using InnoTech.LegosForLife.Core.IServices;
using InnoTech.LegosForLife.Core.Models;

namespace InnoTech.LegosForLife.Domain.Test
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            if (productRepository == null)
            {
                throw new InvalidDataException("ProductRepository Cannot Be Null");
            }
            _productRepository = productRepository;
        }
        public List<Product> GetProducts()
        {
            _productRepository.FindAll();
            return null;
        }
    }
}