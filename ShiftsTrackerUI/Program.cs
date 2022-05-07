using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ShiftsTrackerUI.Models;

namespace ShiftsTrackerUI
{ 
    class Program
    {
        static void Main()
        {
            UserCommands userCommands = new UserCommands();
            userCommands.UserInterface();
        }
    }
}
    
