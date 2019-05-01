using System;
using System.Collections.Generic;

namespace Challenge_8
{
    internal class DriverRepository
    {
        private List<Driver> _drivers;

        public List<Driver> GetDrivers()
        {
            _drivers = new List<Driver>();
            return _drivers;
        }
        public void AddCarToDriver(Car car, Driver driver)
        {
            foreach (var driverInList in _drivers)
            {
                if (driverInList.FullName == driver.FullName)
                    driverInList.Cars.Add(car);
            }
        }
    }
}