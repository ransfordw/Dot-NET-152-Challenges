using System.Collections.Generic;
using System.Text;

namespace Challenge_1
{
    public class MenuRepository
    {
        private readonly List<MenuItem> _menuItems = new List<MenuItem>
        {
            new MenuItem("Arroz con Pollo", "Mexican rice with grilled chicken and white cheese.", "Rice, Chicken, Cheese, Spices.", 12.0m),
            new MenuItem("Mac N' Cheese", "Kraft macaroni and cheese", "Macaroni pasta, milk, butter, powdered cheese mix.", 1.50m),
            new MenuItem("Flame-grilled Hamburger", "Delicious burger grilled over open flame, lightly seasoned.", "Ground beef, brioche bun, salt, pepper, rosemary, butter.", 14.0m)

        };
       
        //Methods
        public void AddItemToMenu(MenuItem newMenuItem)
        {
            _menuItems.Add(newMenuItem);
        }

        public List<MenuItem> GetMenuItemList()
        {
            return _menuItems;
        }

        public void RemoveItemFromMenu(MenuItem meal)
        {
            _menuItems.Remove(meal);
        }

        public string IngredientsToString(List<string> ingredients)
        {
            var builder = new StringBuilder();

            foreach (var ingredient in ingredients)
                builder.Append(ingredient).Append(", ");

            builder.Length -= 2;
            return builder.ToString();
        }
    }
}
