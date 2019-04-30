using System.Collections.Generic;

namespace Challenge_8
{
    internal class SmartCarRepository
    {
        private readonly DriverRepository _driverRepo = new DriverRepository();
        private List<Driver> _driverList = new List<Driver>();

        public List<Driver> GetDrivers()
        {
            _driverList = new List<Driver>();
            return _driverList;
        }

        public void AddDriver(Driver driver)
        {
            _driverList.Add(driver);
        }

        public void AddCarToDriver(Car car)
        {
            _driverRepo.AddCarToDriver(car);
        }
    }
}