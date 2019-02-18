namespace Challenge_7
{
    class ConcreteBoothFactory : BoothFactory
    {
        public override IBooth GetBooth(int userInput, string name, decimal mainCost, decimal miscCost)
        {
            switch (userInput)
            {
                case 1:
                    return new BurgerBooth(name, mainCost, miscCost);
                default:
                    return new DessertBooth(name, mainCost, miscCost);
            }
        }
    }
}
