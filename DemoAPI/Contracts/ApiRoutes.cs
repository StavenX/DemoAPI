using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Contracts
{
    public static class ApiRoutes
    {
        public static class Players
        {
            public const string GetAll       = "api/player/all";
            public const string Get          = "api/player/{id}";
            public const string Add          = "api/player/add";
            public const string Delete       = "api/player/delete/{id}";
            public const string Edit         = "api/player/edit/{id}";
        }

        public static class Scores
        {
            public const string GetAll       = "api/score/all";
            public const string Get          = "api/score/{id}";
            public const string Add          = "api/score/add";
            public const string Delete       = "api/score/delete/{id}";
            public const string GetForPlayer = "api/score/player";
        }

        public static class WeeklySummaries
        {
            public const string GetWeeklies  = "api/weeklysummary/{weekNumber}";
        }

        public static class ImpactReports
        {
            public const string GetImpacts   = "api/impactreport/reports";
        }
    }
}
