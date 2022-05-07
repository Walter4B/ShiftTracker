using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftsTrackerUI
{
    internal class Validator
    {
        internal bool CheckIfInt(string input)
        { 
            if(Int32.TryParse(input, out _))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal bool CheckIfDecimal(string input)
        {
            if (Decimal.TryParse(input, out _))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal bool CheckIfEmptyOrNull(string input)
        {
            if (CheckIfEmptyOrNull(input))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
