using DemoAPI.Models;
using System;
using System.Collections.Generic;

namespace DemoAPI.Factories
{
    public interface IImpactReportFactory
    {
        public ImpactReport GetImpactReportForPlayer(Guid playerId);
        public List<ImpactReport> GetAllImpactReports();
    }
}
