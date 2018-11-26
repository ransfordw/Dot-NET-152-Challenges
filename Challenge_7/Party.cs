using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_7
{
    class Party
    {
        public BurgerBooth BurgerBooth { get; set; }
        public DessertBooth DessertBooth { get; set; }
        public decimal TotalCost { get; set; }
        public int TotalTickets { get; set; }
        public object PartyName { get; internal set; }

        public Party(string name, BurgerBooth burgerBooth,  DessertBooth dessertBooth)
        {
            PartyName = name;
            BurgerBooth = burgerBooth;
            DessertBooth = dessertBooth;
            TotalTickets = burgerBooth.TicketsTaken + dessertBooth.TicketsTaken;
        }

        public override string ToString() => $"Party Name: {PartyName}\nBurger Booth Name: {BurgerBooth.BoothName}\nDessert Booth Name: {DessertBooth.BoothName}\nTotal Tickets: {TotalTickets}\nTotal Cost: {TotalCost}";
    }
}
