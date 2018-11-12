using System;

namespace Challenge_6
{
    public class ProgramUI
    {
        public void Run()
        {
            CarRepository carRepo = new CarRepository();
            var cars = carRepo.GetCarList();
            carRepo.AddCarToList(carRepo.CreateCar("Ford", "Explorer", CarType.Gas, 17));
            carRepo.AddCarToList(carRepo.CreateCar("Tesla", "Model S", CarType.Electric, 54));
            carRepo.AddCarToList(carRepo.CreateCar("Dodge", "Charger", CarType.Hybrid, 25));

            Console.WriteLine("Welcome to Komodo!");
            bool running = true;
            while (running)
            {
                Console.WriteLine("What would you like to do?\n\t" +
                    "1. See all cars\n\t" +
                    "2. Add new car\n\t" +
                    "3. Remove car\n\t" +
                    "4. Update car\n\t" +
                    "5. Exit");
                int response = int.Parse(Console.ReadLine());
                switch (response)
                {
                    case 1:
                        PrintCars();
                        break;
                    case 2:
                        Console.Write("Enter the make of the car: ");
                        var make = Console.ReadLine();
                        Console.Write("Enter the model of the car: ");
                        var model = Console.ReadLine();
                        Console.WriteLine("Select a fuel type: \n\t" +
                            "1. Gas\n\t" +
                            "2. Hybrid\n\t" +
                            "3. Electric");
                        var fuelInput = int.Parse(Console.ReadLine());
                        var type = carRepo.GetFuelType(fuelInput);
                        Console.Write("Enter the miles per fuel unit: ");
                        var milesPer = int.Parse(Console.ReadLine());
                        var car = carRepo.CreateCar(make, model, type, milesPer);
                        carRepo.AddCarToList(car);
                        break;
                    case 3:
                        Console.WriteLine("Would you like to remove a car?");
                        var removeResp = Console.ReadLine();
                        carRepo.YesNoResponse(removeResp);
                        Console.WriteLine("Enter the number of the car you'd like to remove: ");

                        var carRemove = PrintCars();
                        var remove = cars[carRemove - 1];
                        carRepo.RemoveCar(remove);
                        break;
                    case 4:
                        Console.WriteLine("Enter the number for the car you'd like to edit: ");
                        var updateInput = PrintCars();
                        var updateCar = cars[updateInput - 1];
                        Console.WriteLine("Would you like to update the model? y/n");
                        var resp = Console.ReadLine();
                        if (carRepo.YesNoResponse(resp))
                        {
                            Console.WriteLine("Enter new model: ");
                            updateCar.CarModel = Console.ReadLine();
                        }
                        Console.WriteLine("Would you like to update the make? y/n");
                        resp = Console.ReadLine();
                        if (carRepo.YesNoResponse(resp))
                        {
                            Console.WriteLine("Enter new make: ");
                            updateCar.CarMake = Console.ReadLine();
                        }
                        Console.WriteLine("Would you like to update the fuel type? y/n");
                        resp = Console.ReadLine();
                        if (carRepo.YesNoResponse(resp))
                        {
                            Console.WriteLine("Select a fuel type: \n\t" +
                           "1. Gas\n\t" +
                           "2. Hybrid\n\t" +
                           "3. Electric");
                            var fueltypeUpdate = int.Parse(Console.ReadLine());
                            updateCar.FuelType = carRepo.GetFuelType(fueltypeUpdate);
                        }
                        Console.WriteLine("Would you like to update the miles per fuel unit? y/n");
                        resp = Console.ReadLine();
                        if (carRepo.YesNoResponse(resp))
                        {
                            Console.WriteLine("Enter new miles per unit: ");
                            updateCar.MilesPer = int.Parse(Console.ReadLine());
                        }
                        break;
                    default:
                        break;
                }
            }
            int PrintCars()
            {
                Console.WriteLine("Car Make \tModel \t Fuel Type \t Miles Per Fuel Unit");
                int i = 1;
                foreach (Car c in cars)
                {
                    Console.WriteLine($"{i}. {c.CarMake} \t{c.CarModel} \t{c.FuelType} \t{c.MilesPer}");
                    i += 1;
                }
                var menuChoice = int.Parse(Console.ReadLine());
                return menuChoice;
            }
        }
    }
}