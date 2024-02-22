using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCartLibrary.Model; 
namespace ShoppingCartTests
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void Product_Id_Should_Be_Set_And_Get_Correctly()
        {
            // Arrange
            var product = new Product();
            product.Id = 1;

            // Act
            var result = product.Id;

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Product_Name_Should_Be_Set_And_Get_Correctly()
        {
            // Arrange
            var product = new Product();
            product.Name = "Test Product";

            // Act
            var result = product.Name;

            // Assert
            Assert.AreEqual("Test Product", result);
        }

        [TestMethod]
        public void Product_Price_Should_Be_Set_And_Get_Correctly()
        {
            // Arrange
            var product = new Product();
            product.Price = 9.99m;

            // Act
            var result = product.Price;

            // Assert
            Assert.AreEqual(9.99m, result);
        }

        [TestMethod]
        public void Product_Description_Should_Be_Set_And_Get_Correctly()
        {
            // Arrange
            var product = new Product();
            product.Description = "Description";

            // Act
            var result = product.Description;

            // Assert
            Assert.AreEqual("Description", result);
        }
    }
}
