using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenge_6
{
    public class ProgramUI
    {
        private readonly CarRepository _carRepo = new CarRepository();
        private bool _isRunning;
        private static List<Car> _cars;
        public void Run()
        {
            _cars = _carRepo.GetCarList();
            SeedData();

            Console.WriteLine("Welcome to Komodo!");
            _isRunning = true;
            while (_isRunning)
            {
                var response = MenuSelection();
                switch (response)
                {
                    case 1:
                        PrintCars();
                        break;
                    case 2:
                        AddNewCar();
                        break;
                    case 3:
                        RemoveCar();
                        break;
                    case 4:
                        EditCar();
                        break;
                    case 5:
                        _isRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }

        private int MenuSelection()
        {
            Console.WriteLine("What would you like to do?\n\t" +
                    "1. See all cars\n\t" +
                    "2. Add new car\n\t" +
                    "3. Remove car\n\t" +
                    "4. Update car\n\t" +
                    "5. Exit");
            return int.Parse(Console.ReadLine());
        }

        private void AddNewCar()
        {
            Console.Write("Enter the make of the car: ");
            var make = Console.ReadLine();
            Console.Write("Enter the model of the car: ");
            var model = Console.ReadLine();
            Console.WriteLine("Select a fuel type: \n\t" +
                "1. Gas\n\t" +
                "2. Hybrid\n\t" +
                "3. Electric");
            var fuelInput = int.Parse(Console.ReadLine());
            var type = _carRepo.GetFuelType(fuelInput);
            Console.Write("Enter the miles per fuel unit: ");
            var milesPer = int.Parse(Console.ReadLine());
            var car = _carRepo.CreateCar(make, model, type, milesPer);
            _carRepo.AddCarToList(car);
        }

        private void RemoveCar()
        {
            Console.WriteLine("Would you like to remove a car?");
            var removeResp = Console.ReadLine();

            if (_carRepo.YesNoResponse(removeResp))
            {
                Console.WriteLine("Enter the number of the car you'd like to remove: ");

                var carId = SelectCarFromMenu();
                var carToRemove = _cars.Single(c => c.CarID == carId);
                _carRepo.RemoveCar(carToRemove);
            }
        }

        private void EditCar()
        {
            Console.WriteLine("Enter the number for the car you'd like to edit: ");
            var carId = SelectCarFromMenu();
            var carToUpdate = _cars.Single(c => c.CarID == carId);

            Console.WriteLine("Would you like to update the model? y/n");
            var resp = Console.ReadLine();
            if (_carRepo.YesNoResponse(resp))
            {
                Console.WriteLine("Enter new model: ");
                carToUpdate.CarModel = Console.ReadLine();
            }

            Console.WriteLine("Would you like to update the make? y/n");
            resp = Console.ReadLine();
            if (_carRepo.YesNoResponse(resp))
            {
                Console.WriteLine("Enter new make: ");
                carToUpdate.CarMake = Console.ReadLine();
            }

            Console.WriteLine("Would you like to update the fuel type? y/n");
            resp = Console.ReadLine();
            if (_carRepo.YesNoResponse(resp))
            {
                Console.WriteLine("Select a fuel type: \n\t" +
               "1. Gas\n\t" +
               "2. Hybrid\n\t" +
               "3. Electric");
                var fueltypeUpdate = int.Parse(Console.ReadLine());
                carToUpdate.FuelType = _carRepo.GetFuelType(fueltypeUpdate);
            }

            Console.WriteLine("Would you like to update the miles per fuel unit? y/n");
            resp = Console.ReadLine();
            if (_carRepo.YesNoResponse(resp))
            {
                Console.WriteLine("Enter new miles per unit: ");
                carToUpdate.MilesPer = int.Parse(Console.ReadLine());
            }
        }

        private static void PrintCars()
        {
            Console.WriteLine("Car ID\t Car Make \tModel \t Fuel Type \t Miles Per Fuel Unit");

            foreach (var c in _cars)
                Console.WriteLine($"{c.CarID} \t{c.CarMake} \t{c.CarModel} \t{c.FuelType} \t{c.MilesPer}");
        }
        private static int SelectCarFromMenu()
        {
            PrintCars();

            return int.Parse(Console.ReadLine());
        }
        private void SeedData()
        {
            _carRepo.AddCarToList(_carRepo.CreateCar("Ford", "Explorer", CarType.Gas, 17));
            _carRepo.AddCarToList(_carRepo.CreateCar("Tesla", "Model S", CarType.Electric, 54));
            _carRepo.AddCarToList(_carRepo.CreateCar("Dodge", "Charger", CarType.Hybrid, 25));
        }
    }
}