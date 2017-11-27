using System;
using System.Collections.Generic;

namespace Performance.Web.Imports
{
    public partial class StockItemStockGroups
    {
        public int StockItemStockGroupId { get; set; }
        public int StockItemId { get; set; }
        public int StockGroupId { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }
        public Guid TenantId { get; set; }

        public People LastEdited { get; set; }
        public StockGroups StockGroups { get; set; }
        public StockItems StockItems { get; set; }
    }
}
