using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace Performance.Web.Utilities
{
    public static class Operations
    {
        public static OperationAuthorizationRequirement WeatherForecasts = new OperationAuthorizationRequirement()
        {
            Name = "WeatherForecasts",
        };
        public static OperationAuthorizationRequirement DashboardOverview = new OperationAuthorizationRequirement()
        {
            Name = "DashboardOverview",
        };
    }
}
