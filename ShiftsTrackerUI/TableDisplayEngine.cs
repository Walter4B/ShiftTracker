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
        internal void DisplayTable(List<Shift> shifts, List<string> titles)
        {
            ConsoleTableBuilder
                .From(shifts)
                .WithColumn(titles)
                .WithFormat(ConsoleTableBuilderFormat.Alternative)
                .ExportAndWriteLine();
        }
    }
}
