using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Performance.Web.Utilities
{
    public class WeatherTenantFeature : ITenantResource
    {
        // this feature can only be used by this tenant
        public IEnumerable<Guid> TenantIds { get; } = new Guid[] { Guid.Parse("7C57FCD3-517D-4921-BD65-27E1068FD195") };

        private WeatherTenantFeature() { }

        private static readonly WeatherTenantFeature instance = new WeatherTenantFeature();

        public static WeatherTenantFeature Instance => instance;

        public string ResourceName => "Weather";
    }
}
