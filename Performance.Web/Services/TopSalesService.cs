using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Performance.Web.Imports;

namespace Performance.Web.Services
{
    public interface ITopSalesService
    {
        IEnumerable<TopSalesByTenantIdAndState> GetTopTenSalesByTenantAndState(IEnumerable<Guid> tenantIds);
        IEnumerable<LastTenInvoices> GetLastTenInvoicesByTenant(IEnumerable<Guid> tenantIds);
        IEnumerable<LastTenSales> GetLastTenOrdersByTenant(IEnumerable<Guid> tenantIds);
    }

    public class TopSalesService : ITopSalesService
    {
        readonly ImportersContext importersContext;
        public TopSalesService(ImportersContext importersContext)
        {
            this.importersContext = importersContext;
        }

        public IEnumerable<TopSalesByTenantIdAndState> GetTopTenSalesByTenantAndState(IEnumerable<Guid> tenantIds)
        {

            var sales = (from l in importersContext.InvoiceLines
                         group l by new
                         {
                             l.TenantId,
                             l.Invoices.SalesCustomer.CustomerCity.StateProvinces.StateProvinceName,
                         } into grp
                         select new TopSalesByTenantIdAndState
                         {
                             TenantId = grp.Key.TenantId,
                             StateProvinceName = grp.Key.StateProvinceName,
                             Total = grp.Sum(a => a.ExtendedPrice)
                         }).OrderByDescending(a => a.Total)
                         .Take(10).ToList();

            return sales;
        }

        public IEnumerable<LastTenInvoices> GetLastTenInvoicesByTenant(IEnumerable<Guid> tenantIds)
        {
            var sales = (from i in importersContext.Invoices
                         where tenantIds.Contains(i.TenantId)
                         orderby i.InvoiceDate descending,
                         i.LastEdited descending
                         select new LastTenInvoices
                         {
                             TenantId = i.TenantId,
                             InvoiceId = i.InvoiceId,
                             InvoiceDate = i.InvoiceDate,
                             LastedEditedBy = i.LastEdited.FullName,
                             AccountPerson = i.AccountPerson.FullName,
                             CustomerName = i.SalesCustomer.CustomerName,
                         })
                         .Take(10).ToList();
            return sales;
        }


        public IEnumerable<LastTenSales> GetLastTenOrdersByTenant(IEnumerable<Guid> tenantIds)
        {
            var sales = (from s in importersContext.Orders
                         where tenantIds.Contains(s.TenantId)
                         orderby s.OrderDate descending
                         select new LastTenSales
                         {
                             TenantId = s.TenantId,
                             OrderId = s.OrderId,
                             OrderDate = s.OrderDate,
                             SalesPerson = s.SalesPerson.FullName,
                             CustomerName = s.Customers.CustomerName,
                         })
                         .Take(10).ToList();
            return sales;
        }


    }

    public class LastTenInvoices
    {
        public int InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string LastedEditedBy { get; set; }
        public string AccountPerson { get; set; }
        public string CustomerName { get; set; }
        public Guid TenantId { get; set; }
    }

    public class LastTenSales
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string SalesPerson { get; set; }
        public string CustomerName { get; set; }
        public Guid TenantId { get; set; }
    }

    public class TopSalesByTenantIdAndState
    {
        public Guid TenantId { get; set; }
        public string StateProvinceName { get; set; }
        public decimal Total { get; set; }
    }

}
