using System;
using System.Collections.Generic;

namespace Performance.Web.Imports
{
    public partial class StockItemTransactions
    {
        public int StockItemTransactionId { get; set; }
        public int StockItemId { get; set; }
        public int TransactionTypeId { get; set; }
        public int? CustomerId { get; set; }
        public int? InvoiceId { get; set; }
        public int? SupplierId { get; set; }
        public int? PurchaseOrderId { get; set; }
        public DateTime TransactionOccurredWhen { get; set; }
        public decimal Quantity { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }
        public Guid TenantId { get; set; }

        public Customers Customers { get; set; }
        public Invoices Invoices { get; set; }
        public People LastEdited { get; set; }
        public PurchaseOrders PurchaseOrders { get; set; }
        public StockItems StockItems { get; set; }
        public Suppliers Suppliers { get; set; }
        public TransactionTypes TransactionType { get; set; }
    }
}
