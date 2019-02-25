using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_UtilityMethods
{
    public class UtilityMethodRepository
    {
        public bool ReturnBooleanFromString(string input)
        {
            if (input.ToLower().Contains("y"))
                return true;
            else
                return false;
        }

        
    }
}
