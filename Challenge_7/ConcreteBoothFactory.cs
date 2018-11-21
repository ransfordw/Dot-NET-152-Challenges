using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_7
{
    class ConcreteBoothFactory : BoothFactory
    {
        public override IBooth GetBooth(int userInput, string name, int ticketsTaken, decimal mainCost, decimal miscCost)
        {
            switch (userInput)
            {
                case 1:
                    return new BurgerBooth(name,ticketsTaken, mainCost, miscCost);
                default:
                    return new DessertBooth(name, ticketsTaken, mainCost, miscCost);
            }
        }
    }
}
