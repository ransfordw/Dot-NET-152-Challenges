using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    public class MenuRepository
    {

        private List<MenuItem> _menuItems = new List<MenuItem>();

        //Methods
        public void AddItemToMenu(MenuItem newMenuItem)
        {
            _menuItems.Add(newMenuItem);
        }

        public List<MenuItem> ProduceMenu()
        {
            return _menuItems;
        }

        public void RemoveItemFromMenu(MenuItem meal)
        {
            _menuItems.Remove(meal);
        }

        public string IngredientsToString(List<string> _ingredients)
        {
            StringBuilder builder = new StringBuilder();
            foreach (string ingredient in _ingredients)
            {
                builder.Append(ingredient).Append(", ");
            }
            builder.Length -= 2;
            string result = builder.ToString();
            return result;
        }
    }
}
