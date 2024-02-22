using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCartLibrary.Model; 

namespace ShoppingCartTests
{
    [TestClass]
    public class CategoryTests
    {
        [TestMethod]
        public void Category_Id_Should_Be_Set_And_Get_Correctly()
        {
            // Arrange
            var category = new Category();
            category.Id = 1;

            // Act
            var result = category.Id;

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Category_Description_Should_Be_Set_And_Get_Correctly()
        {
            // Arrange
            var category = new Category();
            category.Description = "Electronics";

            // Act
            var result = category.Description;

            // Assert
            Assert.AreEqual("Electronics", result);
        }

        [TestMethod]
        public void Category_Can_Add_Product()
        {
            // Arrange
            var category = new Category { Id = 1, Description = "Books" };
            var product = new Product { Id = 1, Name = "Test Book" };
            category.Products = new List<Product> { product };

            // Act
            var result = category.Products.Contains(product);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Category_Can_Remove_Product()
        {
            // Arrange
            var category = new Category { Id = 1, Description = "Books" };
            var product = new Product { Id = 1, Name = "Test Book" };
            category.Products = new List<Product> { product };

            // Act
            category.Products.Remove(product);
            var result = category.Products.Contains(product);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
