using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge_1
{
    internal class ProgramUI
    {
        public void Run()
        {
            #region HardCodedValues
            MenuRepository menuRepo = new MenuRepository();
            List<MenuItem> menuItems = menuRepo.ProduceMenu();
            MenuItem arrozConPollo = new MenuItem(1, "Arroz con Pollo", "Mexican rice with grilled chicken and white cheese.", "Rice, Chicken, Cheese, Spices.", 12.0m);
            MenuItem macNCheese = new MenuItem(2, "Mac N' Cheese", "Kraft macaroni and cheese", "Macaroni pasta, milk, butter, powdered cheese mix.", 1.50m);
            MenuItem hambuger = new MenuItem(3, "Flame-grilled Hamburger", "Delicious burger grilled over open flame lightly seasoned.", "Ground beef, brioche bun, sal, pepper, rosemary, butter.", 14.0m);

            menuRepo.AddItemToMenu(arrozConPollo);
            menuRepo.AddItemToMenu(macNCheese);
            menuRepo.AddItemToMenu(hambuger);
            #endregion

            var response = 0;
            while (response != 4)
            {
                Console.WriteLine($"Menu Options\n 1. Add Menu Item\n 2. Remove Menu Item\n 3. Print Menu\n 4. Finish");
                response = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (response)
                {
                    #region Case1
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Menu item number: ");
                        var mealNum = int.Parse(Console.ReadLine());

                        Console.WriteLine("Meal name: ");
                        string mealName = Console.ReadLine();

                        Console.WriteLine("Meal description: ");
                        var description = Console.ReadLine();

                        Console.WriteLine("Meal price: ");
                        decimal price = decimal.Parse(Console.ReadLine());

                        bool ingredientsLoop = true;

                        List<string> _ingredientsFromConsole = new List<string>();

                        while (ingredientsLoop)
                        {
                            Console.WriteLine("Name an ingredient: ");
                            var ingredient = Console.ReadLine();
                            _ingredientsFromConsole.Add(ingredient);

                            Console.WriteLine("Would you like to add another ingredient? y/n");
                            var addIngredientResponse = Console.ReadLine();

                            if (addIngredientResponse == "n")
                                ingredientsLoop = false;
                        }
                        string ingredients = menuRepo.IngredientsToString(_ingredientsFromConsole);

                        MenuItem newMenuItem = new MenuItem(mealNum, mealName, description, ingredients, price);

                        menuRepo.AddItemToMenu(newMenuItem);
                        Console.Clear();
                        break;
                    #endregion
                    #region Case2
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Which item number should be removed?");
                        var removalNum = int.Parse(Console.ReadLine());

                        foreach (MenuItem meal in menuItems)
                        {
                            if (meal.MealNumber == removalNum)
                            {
                                menuRepo.RemoveItemFromMenu(meal);
                                break;
                            }
                        }
                        Console.Clear();
                        break;
                    #endregion
                    #region Case3
                    case 3:
                        foreach (MenuItem meal in menuItems)
                        {
                            Console.WriteLine($"Menu item: {meal.MealName} \n Meal Number:  {meal.MealNumber} \n Description: {meal.Description} \n Ingredients: {meal.Ingredients} \n Price: {meal.MealItemPrice}");
                        }
                        Console.WriteLine("Press 'Enter' to return to menu.");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                        #endregion
                }
            }
        }
    }
}