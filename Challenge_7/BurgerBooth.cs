namespace Challenge_7
{
    public class BurgerBooth : IBooth
    {
        public BurgerBooth(string name, int tickets, decimal cost, decimal misc)
        {
            BoothName = name;
            TicketsTaken = tickets;
            EntreCost = cost;
            MiscCost = misc;
            TotalCost = CalculateTotalCost(tickets, cost, misc);
        }
        public BurgerBooth() { }

        public decimal EntreCost { get; set; }
        public string BoothName { get; set; }
        public int TicketsTaken { get; set; }
        public decimal MiscCost { get; set; }
        public decimal TotalCost { get; set; }

        public decimal CalculateTotalCost(int tickets, decimal cost, decimal misc)
        {
            decimal total = (cost + misc) * tickets;
            return total;
        }
    }
}