using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AspNet.Security.OpenIdConnect.Primitives;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Performance.Models.Security;
using Performance.Web.Services;

namespace Performance.Web.Utilities
{
    public class TenantOperationAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, ITenantResource>
    {

        readonly SecurityContext securityContext;
        readonly IActiveTenantService tenantService;

        public TenantOperationAuthorizationHandler(SecurityContext securityContext, IActiveTenantService tenantService)
        {
            this.securityContext = securityContext;
            this.tenantService = tenantService;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, ITenantResource resource)
        {
            var tenantIds = resource.TenantIds;
            var resourceName = resource.ResourceName;
            var action = requirement.Name;
            var userId = context.User.GetUserId();

            Action<IAuthorizationRequirement> requirementResult = (r) => context.Fail();

            var connection = securityContext.Database.GetDbConnection();

            if (connection.State != ConnectionState.Open)
            {
                await connection.OpenAsync();
            }
            var mvc = context.Resource;

            var resultParam = new SqlParameter()
            {
                ParameterName = "@Result",
                SqlDbType = SqlDbType.Bit,
                Direction = ParameterDirection.Output,
                Value = false
            };

            var checkAccessParams = new SqlParameter[] {
                        new SqlParameter("@UserId", userId),
                        tenantIds.ToTenantSqlParameter("@TenantIds"),
                        new SqlParameter("@Resource", resourceName),
                        new SqlParameter("@Action", action),
                        resultParam,
                    };

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "[Security].[CheckAccess]";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddRange(checkAccessParams);
                await command.ExecuteNonQueryAsync();
            }

            var result = (bool)resultParam.Value;

            if (result)
            {
                requirementResult = context.Succeed;
            }
            
            // evaluate result
            requirementResult?.Invoke(requirement);
        }
    }
}
