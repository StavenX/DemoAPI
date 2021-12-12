using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Routes
{
    public static class ApiRoutes
    {
        public static class Players
        {
            public const string GetAll       = "api/players";
            public const string Get          = "api/players/{id}";
            public const string Add          = "api/players";
            public const string Delete       = "api/players/{id}";
            public const string Edit         = "api/players/{id}";
        }

        public static class Scores
        {
            public const string GetAll       = "api/scores";
            public const string Get          = "api/scores/{id}";
            public const string Add          = "api/scores";
            public const string Delete       = "api/scores/{id}";
            public const string GetForPlayer = "api/scores/player";
        }

        public static class WeeklySummaries
        {
            public const string GetWeeklies  = "api/weeklyreports/{weekNumber}";
        }

        public static class ImpactReports
        {
            public const string GetImpacts   = "api/impactreports";
        }
    }
}
