using System;
using System.Collections.Generic;

namespace Challenge_1
{
    class ProgramUI
    {
        MenuRepository _menuRepo = new MenuRepository();
        List<MenuItem> _menuItems;
        int _response;

        public void Run()
        {
            _menuItems = _menuRepo.ProduceMenu();
            SeedData();

            while (_response != 4)
            {
                PrintMenu();
                switch (_response)
                {
                    case 1:
                        Console.WriteLine("Meal name: ");
                        string mealName = Console.ReadLine();

                        Console.WriteLine("\nMeal description: ");
                        var description = Console.ReadLine();

                        Console.WriteLine("\nMeal price: ");
                        decimal price = decimal.Parse(Console.ReadLine());

                        bool ingredientsLoop = true;

                        List<string> ingredientsFromConsole = new List<string>();

                        while (ingredientsLoop)
                        {
                            Console.WriteLine("Name an ingredient: ");
                            var ingredient = Console.ReadLine();
                            ingredientsFromConsole.Add(ingredient);

                            Console.WriteLine("Would you like to add another ingredient? y/n");
                            var addIngredientResponse = Console.ReadLine().ToLower();

                            if (addIngredientResponse.Contains("n"))
                                ingredientsLoop = false;
                        }
                        string ingredients = _menuRepo.IngredientsToString(ingredientsFromConsole);

                        _menuRepo.AddItemToMenu(new MenuItem(mealName, description, ingredients, price));
                        break;
                    case 2:
                        PrintMeals();
                        Console.WriteLine("Which item number should be removed?");
                        var removalNum = int.Parse(Console.ReadLine());

                        _menuRepo.RemoveItemFromMenu(_menuItems[removalNum - 1]);
                        break;
                    case 3:
                        PrintMeals();
                        break;
                }
                Console.WriteLine("Press any key to return to menu...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void PrintMeals()
        {
            int i = 1;
            foreach (MenuItem meal in _menuItems)
            {
                Console.WriteLine($"Menu item: {meal.MealName} \n Meal Number: {i} \n Description: {meal.Description} \n Ingredients: {meal.Ingredients} \n Price: {meal.MealPrice}");
                i++;
            }
        }

        private void PrintMenu()
        {
            Console.WriteLine($"Menu Options\n 1. Add Menu Item\n 2. Remove Menu Item\n 3. Print Menu\n 4. Finish");
            _response = int.Parse(Console.ReadLine());
        }

        private void SeedData()
        {
            _menuRepo.AddItemToMenu(new MenuItem("Arroz con Pollo", "Mexican rice with grilled chicken and white cheese.", "Rice, Chicken, Cheese, Spices.", 12.0m));
            _menuRepo.AddItemToMenu(new MenuItem("Mac N' Cheese", "Kraft macaroni and cheese", "Macaroni pasta, milk, butter, powdered cheese mix.", 1.50m));
            _menuRepo.AddItemToMenu(new MenuItem("Flame-grilled Hamburger", "Delicious burger grilled over open flame, lightly seasoned.", "Ground beef, brioche bun, salt, pepper, rosemary, butter.", 14.0m));
        }
    }
}