using System;
using System.Collections.Generic;

namespace Performance.Web.Imports
{
    public partial class StockItemHoldings
    {
        public int StockItemId { get; set; }
        public int QuantityOnHand { get; set; }
        public string BinLocation { get; set; }
        public int LastStocktakeQuantity { get; set; }
        public decimal LastCostPrice { get; set; }
        public int ReorderLevel { get; set; }
        public int TargetStockLevel { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }
        public Guid TenantId { get; set; }

        public People LastEdited { get; set; }
        public StockItems StockItems { get; set; }
    }
}
