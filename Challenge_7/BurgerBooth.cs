namespace Challenge_7
{
    public class BurgerBooth : IBooth
    {
        private decimal _totalCostByTicket;

        public decimal EntreCost { get; set; }
        public string BoothName { get; set; }
        public int TicketsTaken { get; set; }
        public decimal MiscCost { get; set; }

        public decimal TotalCostPerTicket
        {
            get => _totalCostByTicket;
            set { _totalCostByTicket = MiscCost + EntreCost; }
        }

        public BurgerBooth(string name, decimal cost, decimal misc)
        {
            BoothName = name;
            EntreCost = cost;
            MiscCost = misc;
            TotalCostPerTicket = TotalCostPerTicket;
        }

        public BurgerBooth() { }

    }
}