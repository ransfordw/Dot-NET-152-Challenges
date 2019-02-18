using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_7
{
    public interface IBooth
    {
        string BoothName { get; set; }
        int TicketsTaken { get; set; }
        decimal MiscCost { get; set; }

        //decimal CalculateTotalCost(int tickets, decimal cost, decimal misc);
    }
}
