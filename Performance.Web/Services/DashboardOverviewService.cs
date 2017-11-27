using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Performance.Web.Models;

namespace Performance.Web.Services
{
    public interface IDashboardOverviewService
    {
        DashboardOverview GetDashboardOverviewForUser(Guid userId);
    }
    public class DashboardOverviewService : IDashboardOverviewService
    {
        readonly IActiveTenantService activeTenantService;
        readonly IAllowedTenantService allowedTenantService;
        readonly ITopSalesService topSalesService;

        public DashboardOverviewService(
            IActiveTenantService activeTenantService,
            IAllowedTenantService allowedTenantService,
            ITopSalesService topSalesService
            )
        {
            this.allowedTenantService = allowedTenantService;
            this.activeTenantService = activeTenantService;
            this.topSalesService = topSalesService;
        }

        public DashboardOverview GetDashboardOverviewForUser(Guid userId)
        {
            var activeTenants = activeTenantService.GetActiveTenants();
            var myAllowedTenants = allowedTenantService.GetAllowedTenants(userId);

            var overview = new DashboardOverview();

            // build allowed tenants
            var allowedTenantsList = myAllowedTenants
                .Select(t => activeTenants.FirstOrDefault(at => at.Id == t))
                .Select(t => new AllowedTenant
                {
                    Id = t.Id,
                    Name = t.Name,
                });

            overview.AllowedTenants = allowedTenantsList;

            // top 10 sales by tenant/state
            var topSales = topSalesService.GetTopTenSalesByTenantAndState(allowedTenantsList.Select(a => a.Id));

            var topSalesList = (from s in topSales
                                let t = allowedTenantsList.FirstOrDefault(at => at.Id == s.TenantId)
                                select new TopSalesByTenantAndState
                                {
                                    // used to map row in UI
                                    Id = Guid.NewGuid(),
                                    Tenant = t,
                                    BillingState = s.StateProvinceName,
                                    TotalSales = s.Total,
                                }).ToList();

            overview.TopSales = topSalesList;

            // last 10 sales
            var lastSales = topSalesService.GetLastTenInvoicesByTenant(allowedTenantsList.Select(a => a.Id));

            var lastSalesList = (from s in lastSales
                                 let t = allowedTenantsList.FirstOrDefault(at => at.Id == s.TenantId)
                                 select new LastTenTenantInvoices
                                 {
                                     // used to map row in UI
                                     AccountPerson = s.AccountPerson,
                                     CustomerName = s.CustomerName,
                                     InvoiceDate = s.InvoiceDate,
                                     InvoiceId = s.InvoiceId,
                                     Tenant = t,
                                 }).ToList();

            overview.LastSales = lastSalesList;

            // last 10 orders
            var lastOrders = topSalesService.GetLastTenOrdersByTenant(allowedTenantsList.Select(a => a.Id));

            var lastOrdersList = (from s in lastOrders
                                  let t = allowedTenantsList.FirstOrDefault(at => at.Id == s.TenantId)
                                 select new LastTenTenantOrders
                                 {
                                     // used to map row in UI
                                     SalesPerson = s.SalesPerson,
                                     CustomerName = s.CustomerName,
                                     OrderDate = s.OrderDate,
                                     OrderId = s.OrderId,
                                     Tenant = t,
                                 }).ToList();

            overview.LastOrders = lastOrdersList;
            return overview;
        }
    }
}
