using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Factories
{
    public interface IWeeklySummaryFactory
    {
        public List<WeeklySummary> GetWeeklySummaries(int weekNumber);
    }
}
