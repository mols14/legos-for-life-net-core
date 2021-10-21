using InnoTech.LegosForLife.Core.IServices;
using Xunit;

namespace InnoTech.LegosForLife.Domain.Test
{
    public class ProductServiceTest
    {
        [Fact]
        public void ProductService_IsIProductService()
        {
            var service = new ProductService();
            Assert.True(service is IProductService);
        }
    }
}