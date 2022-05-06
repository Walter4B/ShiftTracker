using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftsTrackerUI.Models
{
    internal class Shift
    {
        public int ShiftId { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public decimal Pay { get; set; }

        public decimal Minutes { get; set; }

        public string Location { get; set; }
    }
}
