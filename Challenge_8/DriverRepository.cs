using System;

namespace Challenge_8
{
    internal class DriverRepository
    {
        private readonly Driver _driver;
        public void AddCarToDriver(Car car)
        {
            _driver.Cars.Add(car);
        }
    }
}