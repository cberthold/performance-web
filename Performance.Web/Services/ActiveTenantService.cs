using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Performance.Models.Security;

namespace Performance.Web.Services
{
    public interface IActiveTenantService
    {
        IEnumerable<Tenants> GetActiveTenants();
    }

    public class ActiveTenantService : IActiveTenantService
    {
        readonly IEnumerable<Tenants> activeTenants;

        public ActiveTenantService(SecurityContext securityContext)
        {
            activeTenants = RetrieveActiveTenants(securityContext);
        }

        private IEnumerable<Tenants> RetrieveActiveTenants(SecurityContext context)
        {
            var tenants = (from t in context.Tenants
                           where t.IsActive == true
                           orderby t.Name
                           select t).ToList();

            return tenants;
        }

        public IEnumerable<Tenants> GetActiveTenants()
        {
            return activeTenants;
        }
    }
}
