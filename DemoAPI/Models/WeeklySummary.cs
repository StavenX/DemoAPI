using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Models
{
    public class WeeklySummary
    {
        public string PlayerName { get; set; }
        public double HighestDuration { get; set; }
        public int HighestScore { get; set; }
    }
}
