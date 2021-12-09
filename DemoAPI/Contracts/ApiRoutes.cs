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
            public const string GetPlayer    = "api/player/{id}";
            public const string AddPlayer    = "api/player/add";
            public const string DeletePlayer = "api/player/delete/{id}";
            public const string EditPlayer   = "api/player/edit/{id}";
        }

        public static class Scores
        {

        }
    }
}
