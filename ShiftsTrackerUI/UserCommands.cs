using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftsTrackerUI
{

    internal class UserCommands
    {
        internal void UserInterface()
        {
            InputEngine inputEngine = new InputEngine();
            OutputEngine outputEngine = new OutputEngine();
            CRUDEngine crudEngine = new CRUDEngine();

            outputEngine.DisplayMessage("MainMenu");
            int engineCommand = inputEngine.GetInputInt();
            while (engineCommand < 0 && engineCommand > 4)
            {
                if (engineCommand == 0)
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("between 0 and 4");
                    engineCommand = inputEngine.GetInputInt();
                }
            }
            crudEngine.RunEngine(engineCommand);
        }
    }
}
