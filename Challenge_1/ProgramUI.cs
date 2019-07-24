using System;
using System.Collections.Generic;
using System.Threading;

namespace Challenge_1
{
    class ProgramUI
    {
        readonly MenuRepository _menuRepo = new MenuRepository();
        List<MenuItem> _menuItems;
        int _response;

        public void Run()
        {
            _menuItems = _menuRepo.GetMenuItemList();

            while (_response != 4)
            {
                PrintMenu();
                switch (_response)
                {
                    case 1:
                        Console.WriteLine("Meal name: ");
                        var mealName = Console.ReadLine();

                        Console.WriteLine("\nMeal description: ");
                        var description = Console.ReadLine();

                        Console.WriteLine("\nMeal price: ");
                        var price = decimal.Parse(Console.ReadLine());

                        var isAddingIngredients = true;

                        var ingredientsFromConsole = new List<string>();

                        while (isAddingIngredients)
                        {
                            Console.WriteLine("Name an ingredient: ");
                            var ingredient = Console.ReadLine();
                            ingredientsFromConsole.Add(ingredient);

                            try
                            {
                                Console.WriteLine("Would you like to add another ingredient? y/n");
                                var addIngredientResponse = Console.ReadLine().ToLower();

                                if (!addIngredientResponse.Contains("n") && !addIngredientResponse.Contains("y"))
                                    throw new ArgumentException("Please enter \"n\" or \"y\".");
                                if (addIngredientResponse == "n")
                                    isAddingIngredients = false;
                            }
                            catch (Exception ex) { Console.WriteLine(ex.Message); }
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
            var isValidResponse = false;
            while (!isValidResponse)
            {
                try
                {
                    Console.WriteLine($"Menu Options\n 1. Add Menu Item\n 2. Remove Menu Item\n 3. Print Menu\n 4. Finish");
                    isValidResponse = int.TryParse(Console.ReadLine(), out _response);
                    if (!isValidResponse) throw new InvalidCastException("The input was not a number");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR: {ex.Message}. Please try again...");
                    Thread.Sleep(1500);
                    Console.Clear();
                }
            }
        }
    }
}