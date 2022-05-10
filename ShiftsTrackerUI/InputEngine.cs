using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftsTrackerUI
{
    internal class InputEngine
    {
        Validator validator = new Validator();
        OutputEngine outputEngine = new OutputEngine();

        internal string GetInputString()
        {
            string inputString = Console.ReadLine();
            while (validator.CheckIfEmptyOrNull(inputString))
            {
                outputEngine.DisplayMessage("InvalidInput");
                inputString = Console.ReadLine();
            }
            return inputString;
        }

        internal decimal GetInputDecimal()
        {
            string input = Console.ReadLine();
            while (!validator.CheckIfDecimal(input))
            {
                outputEngine.DisplayMessage("InvalidInput");
                input = Console.ReadLine();
            }

            return Convert.ToDecimal(input);
        }

        internal int GetInputInt()
        { 
            string input = Console.ReadLine();
            while (!validator.CheckIfInt(input))
            {
                outputEngine.DisplayMessage("InvalidInput");
                input = Console.ReadLine();
            }

            return Convert.ToInt32(input);
        }

        internal DateTime GetInputDateTime()
        {
            string input = Console.ReadLine();
            while (!validator.CheckIfDateTime(input))
            {
                outputEngine.DisplayMessage("InvalidInput");
                input = Console.ReadLine();
            }

            return Convert.ToDateTime(input);
        }
    }
}
