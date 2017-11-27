using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Performance.Web.Utilities
{
    public interface ITenantResource
    {
        string ResourceName { get; }
        IEnumerable<Guid> TenantIds { get; }
    }
}
