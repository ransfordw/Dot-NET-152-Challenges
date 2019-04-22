namespace Challenge_8
{
    internal class SmartCarRepository
    {
        private readonly DriverRepository _driverRepo = new DriverRepository();

        public void AddCarToDriver(Car car)
        {
            _driverRepo.AddCarToDriver(car);
        }
    }
}