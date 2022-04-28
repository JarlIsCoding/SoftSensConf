using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftSensConf
{
    public class Instrument
    {
        public Instrument() { }
        public string instrumentName { get; set; }
        public double lowerRangeValue { get; set; } = 0.0;
        public double upperRangeValue { get; set; } = 0.0;
        public double lowerAlarm { get; set; } = 0.0;
        public double upperAlarm { get; set; } = 0.0;
        public bool State { get; set; }
        public string Span() 
        { return (lowerRangeValue.ToString() + upperRangeValue.ToString()); }
    
    }
}
