namespace Challenge_7
{
    public class BurgerBooth : IBooth
    {
        public BurgerBooth(string name, decimal cost, decimal misc)
        {
            BoothName = name;
            EntreCost = cost;
            MiscCost = misc;
        }

        public BurgerBooth() { }

        public decimal EntreCost { get; set; }
        public string BoothName { get; set; }
        public int TicketsTaken { get; set; }
        public decimal MiscCost { get; set; }
        public decimal TotalCost { get; set; }

        public decimal CalculateTotalCost(int tickets)
        {
            decimal total = (EntreCost + MiscCost) * tickets;
            return total;
        }
    }
}