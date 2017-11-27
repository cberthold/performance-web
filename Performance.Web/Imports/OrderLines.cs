using System;
using System.Collections.Generic;

namespace Performance.Web.Imports
{
    public partial class OrderLines
    {
        public int OrderLineId { get; set; }
        public int OrderId { get; set; }
        public int StockItemId { get; set; }
        public string Description { get; set; }
        public int PackageTypeId { get; set; }
        public int Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal TaxRate { get; set; }
        public int PickedQuantity { get; set; }
        public DateTime? PickingCompletedWhen { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }
        public Guid TenantId { get; set; }

        public Orders Orders { get; set; }
        public PackageTypes PackageTypes { get; set; }
        public People People { get; set; }
        public StockItems StockItems { get; set; }
    }
}
