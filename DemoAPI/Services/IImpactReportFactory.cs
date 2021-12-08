using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Services
{
    public interface IImpactReportFactory
    {
        public ImpactReport GetImpactReportForPlayer(Guid playerId);
        public List<ImpactReport> GetAllImpactReports();
    }
}
