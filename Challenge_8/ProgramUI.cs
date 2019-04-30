using System;

namespace Challenge_8
{
    internal class ProgramUI
    {
        readonly SmartCarRepository _smartRepo = new SmartCarRepository();
        internal void Run()
        {
            SeedDrivers();
            SeedCars();
            throw new NotImplementedException();
        }

        private void SeedCars()
        {
            var ford = new Car(CarMake.Ford, CarType.SUV, 1993, 185000, false, true, new TimeSpan(0, 30, 0), 4, 7, 1);

        }

        private void SeedDrivers()
        {
            _smartRepo.AddDriver(new Driver("Chuck", "Norris", 75));
            _smartRepo.AddDriver(new Driver("Karen", "Smith", 45));
        }
    }
}