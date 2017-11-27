using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Performance.Models.Security;

namespace Performance.Web.Services
{
    public interface IUserPermissionsService
    {
        IEnumerable<UserPermissions> GetAllowedPermissionsByUserId(Guid userId);
    }

    public class UserPermissionsService : IUserPermissionsService
    {
        SecurityContext securityContext;
        public UserPermissionsService(SecurityContext securityContext)
        {
            this.securityContext = securityContext;
        }
        public IEnumerable<UserPermissions> GetAllowedPermissionsByUserId(Guid userId)
        {
            var allowedTenantsList = (from u in securityContext.UserPermissions
                                      where (u.UserId ?? Guid.Empty) == userId
                                      && u.Allowed
                                      && u.TenantId != null
                                      select u).ToList();
            
            return allowedTenantsList;
        }
    }
}
