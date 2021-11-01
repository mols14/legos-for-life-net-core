using System.Collections.Generic;
using System.Linq;
using InnoTech.LegosForLife.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Xunit;
using System.Reflection;
using InnoTech.LegosForLife.Core.Models;
using TypeInfo = System.Reflection.TypeInfo;

namespace InnoTech.LegosForLife.WebApi.Test.Controllers
{
    public class ProductControllerTest
    {
        [Fact]
        public void ProductController_IsOfTypeControllerBase()
        {
            var controller = new ProductController();
            Assert.IsAssignableFrom<ControllerBase>(controller);
        }
        
        [Fact]
        public void ProductController_UsesApiControllerAttribute()
        {
            //Arrange
            var typeInfo = typeof(ProductController).GetTypeInfo();
            var attr = typeInfo
                .GetCustomAttributes()
                .FirstOrDefault(a => a.GetType()
                    .Name.Equals("ApiControllerAttribute"));
            //Assert
            Assert.NotNull(attr);
        }  
        
        [Fact]
        public void ProductController_UsesRouteAttribute()
        {  
            //Arrange
            var typeInfo = typeof(ProductController).GetTypeInfo();
            var attr = typeInfo
                .GetCustomAttributes()
                .FirstOrDefault(a => a.GetType()
                    .Name.Equals("RouteAttribute"));
            //Assert
            Assert.NotNull(attr);
        }
        
        [Fact]
        public void ProductController_UsesRouteAttribute_WithParamApiControllerNameRoute()
        {  
            //Arrange
            var typeInfo = typeof(ProductController).GetTypeInfo();
            var attr = typeInfo
                .GetCustomAttributes()
                .FirstOrDefault(a => a.GetType()
                    .Name.Equals("RouteAttribute")) as RouteAttribute;
            //Assert
            Assert.Equal("api/[controller]", attr.Template);
        }
        
        [Fact]
        public void ProductController_HasGetAllMethod()
        {
            var method = typeof(ProductController)
            .GetMethods().FirstOrDefault(m => "GetAll".Equals(m.Name));
            Assert.NotNull(method);
        }
        
        [Fact]
        public void ProductController_HasGetAllMethod_IsPublic()
        {
            var method = typeof(ProductController)
                .GetMethods().FirstOrDefault(m => "GetAll".Equals(m.Name));
            Assert.True(method.IsPublic);
        }
        
        [Fact]
        public void ProductController_HasGetAllMethod_ReturnsListOfProductsInActionResult()
        {
            var method = typeof(ProductController)
                .GetMethods().FirstOrDefault(m => "GetAll".Equals(m.Name));
            Assert.Equal(typeof(ActionResult<List<Product>>).FullName, method.ReturnType.FullName);
        }

        [Fact]
        public void ProductController_GetAllMethod_HasGetHttpAttribute()
        {
            /*
var methodInfo = typeof(ProductController).GetMethods().FirstOrDefault(m => m.Name == "GetAll");
           var attr = methodInfo.CustomAttributes.FirstOrDefault(ca => ca.AttributeType.Name == "HttpGetAttribute");
           Assert.NotNull(attr);*/
        }
    }
}

