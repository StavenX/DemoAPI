using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Models
{
    public class ImpactReport
    {
        public Guid PlayerId { get; set; }
        public string PlayerName { get; set; }
        public double AmountPlayedMinutes { get; set; }
        public int Playthroughs { get; set; }
        public int TotalScore { get; set; }
    }
}
