using System;
using Challenge_7;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_7_Tests
{
    [TestClass]
    public class BoothFactory_Tests
    {
        BoothFactory _factory = new ConcreteBoothFactory();
        [DataTestMethod]
        [DataRow(1,"Burger",12.4, 0.75, typeof(BurgerBooth))]
        [DataRow(2,"Dessert",2.5, 0.50, typeof(DessertBooth))]
        public void BoothFactory_GetBooth_ShouldReturnTypeOfIBooth(int response, string name, double cost, double misc, Type expected)
        {
            var actual = _factory.GetBooth(response, name, (decimal)cost, (decimal)misc);

            Assert.IsInstanceOfType(actual, expected);
        }
    }
}
