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
                .WithColumn("")
                .WithFormat(ConsoleTableBuilderFormat.Alternative)
                .ExportAndWriteLine();
        }
    }
}
