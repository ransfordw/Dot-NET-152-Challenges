namespace Challenge_7
{
    public class DessertBooth : IBooth
    {
        public DessertBooth(string name, decimal cost, decimal misc)
        {
            BoothName = name;
            DessertCost = cost;
            MiscCost = misc;
        }

        public DessertBooth() { }

        public string BoothName { get; set; }
        public int TicketsTaken { get; set; }
        public decimal DessertCost { get; set; }
        public decimal MiscCost { get; set; }
        public decimal TotalCost { get; set; }

        public decimal CalculateTotalCost(int tickets)
        {
            decimal total = (DessertCost + MiscCost) * tickets;
            return total;
        }
    }
}