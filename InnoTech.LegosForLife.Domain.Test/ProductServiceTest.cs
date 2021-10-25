using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using InnoTech.LegosForLife.Core.IServices;
using InnoTech.LegosForLife.Core.Models;
using Moq;
using Xunit;

namespace InnoTech.LegosForLife.Domain.Test
{
    public class ProductServiceTest
    {
        [Fact]
        public void ProductService_IsIProductService()
        {
            var mock = new Mock<IProductRepository>();
            var service = new ProductService(mock.Object);
            Assert.True(service is IProductService);
        }
        
        
        [Fact]
        public void ProductService_WithNullProductRepository_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(
                () => new ProductService(null)
                );

        }
        
        [Fact]
        public void ProductService_WithNullProductRepository_ThrowsExceptionWithMessage()
        {
            var exception = Assert.Throws<InvalidDataException>(
                () => new ProductService(null)
            );
            Assert.Equal("ProductRepository Cannot Be Null",exception.Message);
        }
        
        
        [Fact]
        public void GetProducts_CallsProductRepositoriesFindAll_ExactlyOnce()
        {
            var mock = new Mock<IProductRepository>();
            var service = new ProductService(mock.Object);
            service.GetProducts();
            mock.Verify(r => r.FindAll(), Times.Once);
        }
        
        [Fact]
        public void GetProducts_NoFilter_ReturnsListOfAllProducts()
        {
            var expected = new List<Product>
            {
                new Product { Id = 1, Name = "Lego1" },
                new Product { Id = 2, Name = "Lego2" }
            };
            var mock = new Mock<IProductRepository>();
            mock.Setup(r => r.FindAll())
                .Returns(expected);
            var service = new ProductService(mock.Object);
            var actual = service.GetProducts();
            Assert.Equal(expected, actual);
        }
    }
}