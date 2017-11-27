using System;
using System.Collections.Generic;

namespace Performance.Web.Imports
{
    public partial class PackageTypes
    {
        public PackageTypes()
        {
            InvoiceLines = new HashSet<InvoiceLines>();
            OrderLines = new HashSet<OrderLines>();
            PurchaseOrderLines = new HashSet<PurchaseOrderLines>();
            StockItemsPackageTypes = new HashSet<StockItems>();
            StockItemsPackageTypesNavigation = new HashSet<StockItems>();
        }

        public int PackageTypeId { get; set; }
        public string PackageTypeName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public Guid TenantId { get; set; }

        public People People { get; set; }
        public ICollection<InvoiceLines> InvoiceLines { get; set; }
        public ICollection<OrderLines> OrderLines { get; set; }
        public ICollection<PurchaseOrderLines> PurchaseOrderLines { get; set; }
        public ICollection<StockItems> StockItemsPackageTypes { get; set; }
        public ICollection<StockItems> StockItemsPackageTypesNavigation { get; set; }
    }
}
