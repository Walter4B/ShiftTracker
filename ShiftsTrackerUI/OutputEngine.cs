using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ShiftsTrackerUI
{
    internal class OutputEngine
    {
        private readonly IConfiguration configuration = GetConfig();

        internal void DisplayMessage(string message)
        {
            Console.WriteLine(configuration[message]);
        }

        internal static IConfiguration GetConfig()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("ShiftsTrackerUI/MessageList.json");
            return builder.Build();
        }
    }
}
