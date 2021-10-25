using System.IO;
using EntityFrameworkCore.Testing.Moq;
using InnoTech.LegosForLife.Core.IServices;
using InnoTech.LegosForLife.DataAccess.Repositories;
using InnoTech.LegosForLife.Domain.IRepositories;
using Xunit;

namespace InnoTech.LegosForLife.DataAccess.Test.Repositories
{
    public class ProductRepositoryTest
    {
        [Fact]
        public void ProductRepository_IsIProductRepository()
        {
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new ProductRepository(fakeContext);
            Assert.IsAssignableFrom<IProductRepository>(repository);
        }
        
        [Fact]
        public void ProductRepository_WithNullDBContext_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => new ProductRepository(null));
        }
        
        [Fact]
        public void ProductRepository_WithNullDBContext_ThrowsExceptionWithMessage()
        {
            var exception = Assert
                .Throws<InvalidDataException>(() => new ProductRepository(null));
            Assert.Equal("Product Repository Must have a DBContext", exception.Message);
        }
        
        [Fact]
        public void FindAll_CallsProductDBContext_Once()
        {
            
        }
    }
}