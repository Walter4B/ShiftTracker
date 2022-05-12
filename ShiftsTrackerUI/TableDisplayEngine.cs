using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTableExt;
using ShiftsTrackerUI.Models;

namespace ShiftsTrackerUI
{
    internal class TableDisplayEngine
    {
        internal void DisplayTable(List<Shift> shifts)
        {
            ConsoleTableBuilder
                .From(shifts)
                .WithColumn("Id", "Start", "End", "Pay", "Minutes", "Location")
                .WithFormat(ConsoleTableBuilderFormat.Alternative)
                .ExportAndWriteLine();
        }

        internal void DisplayTable(Shift shift)
        {
            List<Shift> list = new List<Shift>();
            list.Add(shift);

            ConsoleTableBuilder
                .From(list)
                .WithColumn("Id", "Start", "End", "Pay", "Minutes", "Location")
                .WithFormat(ConsoleTableBuilderFormat.Alternative)
                .ExportAndWriteLine();
        }
    }
}
