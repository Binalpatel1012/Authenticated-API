using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCartLibrary.Model; 

namespace ShoppingCartTests
{
    [TestClass]
    public class ShoppingCartTests
    {
        [TestMethod]
        public void ShoppingCart_Id_Should_Be_Set_And_Get_Correctly()
        {
            // Arrange
            var shoppingCart = new ShoppingCart();
            shoppingCart.Id = 1;

            // Act
            var result = shoppingCart.Id;

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void ShoppingCart_User_Should_Be_Set_And_Get_Correctly()
        {
            // Arrange
            var shoppingCart = new ShoppingCart();
            shoppingCart.User = "testuser@example.com";

            // Act
            var result = shoppingCart.User;

            // Assert
            Assert.AreEqual("testuser@example.com", result);
        }

        [TestMethod]
        public void ShoppingCart_Can_Add_Product()
        {
            // Arrange
            var shoppingCart = new ShoppingCart();
            var product = new Product { Id = 1, Name = "Test Product" };
            shoppingCart.Products = new List<Product> { product };

            // Act
            var result = shoppingCart.Products.Contains(product);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ShoppingCart_Can_Remove_Product()
        {
            // Arrange
            var shoppingCart = new ShoppingCart();
            var product = new Product { Id = 1, Name = "Test Product" };
            shoppingCart.Products = new List<Product> { product };

            // Act
            shoppingCart.Products.Remove(product);
            var result = shoppingCart.Products.Contains(product);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
