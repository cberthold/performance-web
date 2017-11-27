using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Performance.Web.Models
{
    public class DashboardOverview
    {
        public IEnumerable<AllowedTenant> AllowedTenants { get; set; }
        public IEnumerable<TopSalesByTenantAndState> TopSales { get; set; }
        public IEnumerable<LastTenTenantInvoices> LastSales { get; internal set; }
        public List<LastTenTenantOrders> LastOrders { get; internal set; }
    }

    public class AllowedTenant
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class TopSalesByTenantAndState
    {
        public Guid Id { get; set; } 
        public AllowedTenant Tenant { get; set; }
        public string BillingState { get; set; }
        public decimal TotalSales { get; set; }
    }

    public class LastTenTenantInvoices
    {
        public int InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string LastedEditedBy { get; set; }
        public string AccountPerson { get; set; }
        public string CustomerName { get; set; }
        public AllowedTenant Tenant { get; set; }
    }

    public class LastTenTenantOrders
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string SalesPerson { get; set; }
        public string CustomerName { get; set; }
        public AllowedTenant Tenant { get; set; }
    }

}
