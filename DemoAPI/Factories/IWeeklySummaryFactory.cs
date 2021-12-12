using DemoAPI.Models;
using System.Collections.Generic;

namespace DemoAPI.Factories
{
    public interface IWeeklySummaryFactory
    {
        public List<WeeklySummary> GetWeeklySummaries(int weekNumber);
    }
}
