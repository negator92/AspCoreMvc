using WorkingWithVisualStudio.Models;
using Xunit;

namespace WorkingWithVisualStudio.Tests
{
    public class ProductTests
    {
        [Fact]
        public void CanChangeProductName()
        {
            var product = new Product {Name = "Test", Price = 100M};
            product.Name = "New Name";
            Assert.Equal("New Name", product.Name);
        }

        [Fact]
        public void CanChangeProductPrice()
        {
            var product = new Product {Name = "Test", Price = 100M};
            product.Price = 200M;
            Assert.Equal(100M, product.Price);
        }
    }
}