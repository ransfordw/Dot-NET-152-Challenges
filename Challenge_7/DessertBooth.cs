namespace Challenge_7
{
    public class DessertBooth : IBooth
    {
        private decimal _totalByTicket;

        public DessertBooth(string name, decimal cost, decimal misc)
        {
            BoothName = name;
            DessertCost = cost;
            MiscCost = misc;
            TotalCostPerTicket = TotalCostPerTicket;
        }

        public DessertBooth() { }

        public string BoothName { get; set; }
        public int TicketsTaken { get; set; }
        public decimal DessertCost { get; set; }
        public decimal MiscCost { get; set; }

        public decimal TotalCostPerTicket
        {
            get => _totalByTicket;
            set { _totalByTicket = DessertCost + MiscCost; }
        }
    }
}