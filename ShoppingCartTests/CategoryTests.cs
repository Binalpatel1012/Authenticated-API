using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCartLibrary.Model;

namespace ShoppingCartTests
{
    [TestClass]
    public class CategoryTests
    {
        [TestMethod]
        public void Category_Id_Should_Be_Set_Correctly()
        {
            // Arrange
            var category = new Category();
            
            // Act
            category.Id = 1;

            // Assert
            Assert.AreEqual(1, category.Id);
        }

        [TestMethod]
        public void Category_Description_Should_Be_Set_Correctly()
        {
            // Arrange
            var category = new Category();
            
            // Act
            category.Description = "Electronics";

            // Assert
            Assert.AreEqual("Electronics", category.Description);
        }

        [TestMethod]
        public void Category_Default_Id_Should_Be_Zero()
        {
            // Arrange
            var category = new Category();

            // Assert
            Assert.AreEqual(0, category.Id);
        }

        [TestMethod]
        public void Category_Default_Description_Should_Be_Null()
        {
            // Arrange
            var category = new Category();

            // Assert
            Assert.IsNull(category.Description);
        }
    }
}
