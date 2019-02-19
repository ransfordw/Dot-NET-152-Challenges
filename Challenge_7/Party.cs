namespace Challenge_7
{
    class Party
    {
        private int _totalTickets;

        public BurgerBooth BurgerBooth { get; set; }
        public DessertBooth DessertBooth { get; set; }
        public int BurgerTickets { get; set; }
        public int DessertTickets { get; set; }
        public decimal TotalCost { get; set; }

        public int TotalTickets
        {
            get => _totalTickets;
            set { _totalTickets = BurgerTickets + DessertTickets; }
        }

        public string PartyName { get; internal set; }

        public Party(string name, BurgerBooth burgerBooth, int burgerTix, DessertBooth dessertBooth, int dessertTix)
        {
            PartyName = name;
            BurgerBooth = burgerBooth;
            DessertBooth = dessertBooth;
            BurgerTickets = burgerTix;
            DessertTickets = dessertTix;
            TotalTickets = burgerTix + dessertTix;
            TotalCost = CalculateTotalPartyCost();
        }

        public override string ToString() => $"Party Name: {PartyName}\nBurger Booth Name: {BurgerBooth.BoothName}\nDessert Booth Name: {DessertBooth.BoothName}\nTotal Tickets: {TotalTickets}\nTotal Cost: {TotalCost}";

        public decimal CalculateTotalPartyCost()
        {
            var burgerTotal = BurgerBooth.TotalCostPerTicket * BurgerTickets;
            var dessertTotal = DessertBooth.TotalCostPerTicket * DessertTickets;

            return burgerTotal + dessertTotal;
        }
    }
}
