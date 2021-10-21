using System.Collections.Generic;
using System.IO;
using InnoTech.LegosForLife.Core.IServices;
using InnoTech.LegosForLife.Core.Models;

namespace InnoTech.LegosForLife.Domain.Test
{
    public class ProductService: IProductService
    {
        public ProductService(IProductRepository productRepository)
        {
            if (productRepository == null)
            {
                throw new InvalidDataException("ProductRepository Cannot Be Null");
            }
        }
        public List<Product> GetProducts()
        {
            throw new System.NotImplementedException();
        }
    }
}