using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShiftsTrackerUI.Models;

namespace ShiftsTrackerUI
{
    internal class DataUserToEngine
    {
        InputEngine inputEngine = new InputEngine();
        

        internal Shift PopulateShiftData()
        {
            Shift shift = new Shift
            {
                Start = DateTime.Now,
            };
            shift.Location = inputEngine.GetInputString();
            shift.Pay = inputEngine.GetInputDecimal();
            shift.Minutes = inputEngine.GetInputDecimal();

            return shift;
        }

        internal int GetShiftId()
        {
            int input = inputEngine.GetInputInt();
            return input;
        }

        internal Shift UpdateEndShift()
        {
            Shift shift = new Shift
            {
                End = DateTime.Now,
            };

            return shift;
        }
    }
}
