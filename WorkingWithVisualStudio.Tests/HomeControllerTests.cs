using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WorkingWithVisualStudio.Controllers;
using WorkingWithVisualStudio.Models;
using Xunit;

namespace WorkingWithVisualStudio.Tests
{
    public class HomeControllerTests
    {
        class ModelCompleteFakeRepository : IRepository
        {
            public IEnumerable<Product> Products { get; set; }

            public void AddProduct(Product product) { /*NOP*/ }
        }

        [Theory]
        [ClassData(typeof(ProductTestData))]
        public void IndexActionModelIsComplete(Product[] products)
        {
            //Arrange
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products).Returns(products);
            HomeController controller = new HomeController() { Repository = mock.Object };

            //Act
            IEnumerable<Product> model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            //Assert
            Assert.Equal(controller.Repository.Products, model,
                Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }

        class PropertyOnceFakeRepository : IRepository
        {
            public int PropertyCounter { get; set; } = 0;

            public IEnumerable<Product> Products
            {
                get
                {
                    PropertyCounter++;
                    return new[] { new Product { Name = "P1", Price = 100 }};
                }
            }

            public void AddProduct(Product product)
            {
                //not required for test
            }
        }

        [Fact]
        public void RepositoryPropertyCalledOnce()
        {
            //Arrange
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products).Returns( new[] { new Product { Name = "P1", Price = 100}});
            HomeController controller = new HomeController() { Repository = mock.Object };

            //Act
            IActionResult result = controller.Index();

            //Assert
            mock.VerifyGet(m => m.Products, Times.Once);
        }
    }
}