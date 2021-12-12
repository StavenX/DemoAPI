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
        public double AmountPlayedSeconds { get; set; }
        public int Playthroughs { get; set; }
        public int TotalScore { get; set; }
        public int FirstScore { get; set; }
        public int BestScore { get; set; }
        public double ImprovedPercentage { get; set; }
    }
}
