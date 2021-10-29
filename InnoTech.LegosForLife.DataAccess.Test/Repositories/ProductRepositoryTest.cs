using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EntityFrameworkCore.Testing.Moq;
using InnoTech.LegosForLife.Core.IServices;
using InnoTech.LegosForLife.Core.Models;
using InnoTech.LegosForLife.DataAccess.Entities;
using InnoTech.LegosForLife.DataAccess.Repositories;
using InnoTech.LegosForLife.Domain.IRepositories;
using Moq;
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
            //Arrange
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new ProductRepository(fakeContext);

            var entityList = new List<ProductEntity>
            {
                new ProductEntity { Name = "Lego1", Id = 1 },
                new ProductEntity { Name = "Lego2", Id = 2 },
                new ProductEntity { Name = "Lego3", Id = 3 },
            };

            fakeContext.Set<ProductEntity>().AddRange(entityList);
            fakeContext.SaveChanges();
            var expectedResult = entityList
                .Select(pe => new Product { Id = pe.Id, Name = pe.Name })
                .ToList();
            
            //Act
            var actualResult = repository.FindAll();
            
            //Assert
            Assert.Equal(expectedResult, actualResult, new IsEqual());

        }
        
        class IsEqual: IEqualityComparer<Product> 
        {
            public bool Equals(Product x, Product y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Id == y.Id && x.Name == y.Name;
            }

            public int GetHashCode(Product obj)
            {
                return HashCode.Combine(obj.Id, obj.Name);
            }
        }
    }
}