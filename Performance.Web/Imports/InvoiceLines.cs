using System;
using System.Collections.Generic;

namespace Performance.Web.Imports
{
    public partial class InvoiceLines
    {
        public int InvoiceLineId { get; set; }
        public int InvoiceId { get; set; }
        public int StockItemId { get; set; }
        public string Description { get; set; }
        public int PackageTypeId { get; set; }
        public int Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal LineProfit { get; set; }
        public decimal ExtendedPrice { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }
        public Guid TenantId { get; set; }

        public Invoices Invoices { get; set; }
        public PackageTypes PackageTypes { get; set; }
        public People LastEdited { get; set; }
        public StockItems StockItems { get; set; }
    }
}
