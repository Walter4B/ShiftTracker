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
        OutputEngine outputEngine = new OutputEngine();

        internal Shift StartShiftPopulate()
        {
            Shift shift = new Shift
            {
                Start = DateTime.Now,
            };
            outputEngine.DisplayMessage("InputLocation");
            shift.Location = inputEngine.GetInputString();
            outputEngine.DisplayMessage("InputPay");
            shift.Pay = inputEngine.GetInputDecimal();

            return shift;
        }

        internal Shift EndShiftPopulate(Shift shift)
        {
            shift.End = DateTime.Now;
            return shift;
        }

        internal Shift FullUpdatePopulate()
        {
            Shift shift = new Shift();
            outputEngine.DisplayMessage("InputDateStart");
            shift.Start = inputEngine.GetInputDateTime();
            outputEngine.DisplayMessage("InputDateEnd");
            shift.End = inputEngine.GetInputDateTime();
            outputEngine.DisplayMessage("InputLocation");
            shift.Location = inputEngine.GetInputString();
            outputEngine.DisplayMessage("InputPay");
            shift.Pay = inputEngine.GetInputDecimal();
            outputEngine.DisplayMessage("InputMinutes");
            shift.Minutes = inputEngine.GetInputDecimal();

            return shift;
        }

        internal int IDshiftPopulate()
        {
            outputEngine.DisplayMessage("InputID");
            int id = inputEngine.GetInputInt();
            return id;
        }

    }
}
