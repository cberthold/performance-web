using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Performance.Models.Security;
using Performance.Web.Models;
using Performance.Web.Services;
using Performance.Web.Utilities;

namespace Performance.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class DashboardController : Controller
    {
        readonly IDashboardOverviewService overviewService;
        readonly IAuthorizationService authorizationService;
        readonly IAllowedTenantService allowedTenantService;


        public DashboardController(
            IDashboardOverviewService overviewService,
            IAuthorizationService authorizationService,
            IAllowedTenantService allowedTenantService
            )
        {
            this.overviewService = overviewService;
            this.authorizationService = authorizationService;
            this.allowedTenantService = allowedTenantService;
        }

        [HttpGet("[action]")]
        public IActionResult Overview()
        {


            var userId = User.GetUserId();
            var allowedTenants = allowedTenantService.GetAllowedTenants(userId);
            var tenantFeature = new MultipleTenants(allowedTenants, "Dashboard");

            var result = authorizationService.AuthorizeAsync(User, tenantFeature, Operations.DashboardOverview).Result;

            if (!result.Succeeded)
            {
                return Challenge();
            }


            var overview = overviewService.GetDashboardOverviewForUser(userId);

            return Ok(overview);
        }
    }
}