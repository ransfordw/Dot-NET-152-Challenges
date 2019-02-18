using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_7
{
    abstract class BoothFactory
    {
        public abstract IBooth GetBooth(int userInput, string name, decimal mainCost, decimal miscCost);
    }
}
