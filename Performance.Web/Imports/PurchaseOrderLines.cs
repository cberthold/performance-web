using System;
using System.Collections.Generic;

namespace Performance.Web.Imports
{
    public partial class PurchaseOrderLines
    {
        public int PurchaseOrderLineId { get; set; }
        public int PurchaseOrderId { get; set; }
        public int StockItemId { get; set; }
        public int OrderedOuters { get; set; }
        public string Description { get; set; }
        public int ReceivedOuters { get; set; }
        public int PackageTypeId { get; set; }
        public decimal? ExpectedUnitPricePerOuter { get; set; }
        public DateTime? LastReceiptDate { get; set; }
        public bool IsOrderLineFinalized { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }
        public Guid TenantId { get; set; }

        public PackageTypes PackageTypes { get; set; }
        public People People { get; set; }
        public PurchaseOrders PurchaseOrders { get; set; }
        public StockItems StockItems { get; set; }
    }
}
