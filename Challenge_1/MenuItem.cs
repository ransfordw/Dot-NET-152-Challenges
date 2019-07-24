namespace Challenge_1
{
    public class MenuItem
    {
        //Constructors
        public MenuItem() { }

        public MenuItem(string mealName, string description, string ingredients, decimal price)
        {
            MealName = mealName;
            Description = description;
            Ingredients = ingredients;
            MealPrice = price;
        }

        //Properties
        public string MealName { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public decimal MealPrice { get; set; }
    }
}
