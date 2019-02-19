using Challenge_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_6_Tests
{
    [TestClass]
    public class Challenege_6_Tests
    {
        private CarRepository _carRepo = new CarRepository();

        [TestMethod]
        public void CarRepository_AddCarToList_ShouldIncreaseCountByOne()
        {
            //--Arrange
            Car car = new Car("Ford", "Explorer", CarType.Gas, 17);
            var cars = _carRepo.GetCarList();
            _carRepo.AddCarToList(car);

            //--Act
            var actual = cars.Count;
            var expected = 1;

            //--Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CarRepository_GetFuelType_ShouldReturnCorrectType()
        {
            //--Arrange

            //--Act
            var actual = _carRepo.GetFuelType(1);
            var expected = CarType.Gas;

            //--Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CarRepository_CreateCar_ShouldReturnCarObject()
        {
            //--Arrange
            var make = "Ford";
            var model = "Fusion";
            var type = CarType.Hybrid;
            var miles = 34;
            var car = _carRepo.CreateCar(make, model, type, miles);

            //--Act
            var actual = car.FuelType;
            var expected = CarType.Hybrid;

            //--Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CarRepository_YesNoResponse_ShouldReturnTrue()
        {
            //--Arrange
            string s = "ywecijwoie";

            //--Act
            var actual = _carRepo.YesNoResponse(s);
            var expected = true;

            //--Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CarRepository_RemoveCar_ShouldReduceCountByOne()
        {
            //--Arrange
            Car car = new Car("Ford", "Explorer", CarType.Gas, 17);
            Car carTwo = new Car("Ford", "Fusion", CarType.Hybrid, 35);
            var cars = _carRepo.GetCarList();
            _carRepo.AddCarToList(car);
            _carRepo.AddCarToList(carTwo);
            _carRepo.RemoveCar(car);

            //--Act
            var actual = cars.Count;
            var expected = 1;

            //--Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
