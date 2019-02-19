namespace Challenge_7
{
    public abstract class BoothFactory
    {
        public abstract IBooth GetBooth(int userInput, string name, decimal mainCost, decimal miscCost);
    }
}
