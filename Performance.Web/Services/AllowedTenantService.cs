using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Performance.Models.Security;

namespace Performance.Web.Services
{
    public interface IAllowedTenantService
    {
        IEnumerable<Guid> GetAllowedTenants(Guid userId);
    }
    public class AllowedTenantService : IAllowedTenantService
    {
        readonly IUserPermissionsService permissionsService;
        public AllowedTenantService(IUserPermissionsService permissionsService)
        {
            this.permissionsService = permissionsService;
        }

        public IEnumerable<Guid> GetAllowedTenants(Guid userId)
        {
            var permissions = permissionsService.GetAllowedPermissionsByUserId(userId);

            var uniqueTenants = permissions.Select(a => a.TenantId.Value).Distinct().ToList();

            return uniqueTenants;
        }
    }
}
