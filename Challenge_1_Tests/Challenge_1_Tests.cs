using Challenge_1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Challenge_1_Tests
{
    [TestClass]
    public class Challenge_1_Tests
    {
        private MenuRepository menuRepoTest;

        [TestInitialize]
        public void Arrange()
        {
            menuRepoTest = new MenuRepository();
        }

        [TestMethod]
        public void MenuRepository_AddItemToMenu_ShouldIncreaseCountByOne()
        {
            MenuItem meal = new MenuItem("Broccoli", "Steamed Broccoli", "Broccoli, butter, spices", 2.0m);
            menuRepoTest.AddItemToMenu(meal);

            var actual = menuRepoTest.GetMenuItemList().Count;
            var expected = 4;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MenuRepository_RemoveItemFromMenu_ShouldReduceCountByOne()
        {
            MenuItem meal = new MenuItem("Broccoli", "Steamed Broccoli", "Broccoli, butter, spices", 2.0m);
            MenuItem mealTwo = new MenuItem("Corn", "Steamed corn", "corn, butter, spices", 2.0m);
            menuRepoTest.AddItemToMenu(meal);
            menuRepoTest.AddItemToMenu(mealTwo);

            menuRepoTest.RemoveItemFromMenu(meal);
            var actual = menuRepoTest.GetMenuItemList().Count;
            var expected = 4;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MenuRepository_BuildIngredientString_ShouldCombineToSingleString()
        {
            string a = "chicken";
            string b = "beef";
            List<string> _ingredients = new List<string>() { a, b };

            var actual = menuRepoTest.IngredientsToString(_ingredients);
            var expeceted = "chicken, beef";

            Assert.AreEqual(expeceted, actual);
        }
    }
}
