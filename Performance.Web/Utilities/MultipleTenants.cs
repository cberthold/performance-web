using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Performance.Web.Utilities
{
    public class MultipleTenants : ITenantResource
    {

        public MultipleTenants(IEnumerable<Guid> tenantIds, string resourceName)
        {
            TenantIds = tenantIds;
            ResourceName = resourceName;
        }

        public IEnumerable<Guid> TenantIds { get; private set; }
        public string ResourceName { get; private set; }
    }
}
