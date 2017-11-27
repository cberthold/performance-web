using System;
using System.Collections.Generic;

namespace Performance.Web.Imports
{
    public partial class Invoices
    {
        public Invoices()
        {
            InvoiceLines = new HashSet<InvoiceLines>();
            StockItemTransactions = new HashSet<StockItemTransactions>();
        }

        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public int BillToCustomerId { get; set; }
        public int? OrderId { get; set; }
        public int DeliveryMethodId { get; set; }
        public int ContactPersonId { get; set; }
        public int AccountsPersonId { get; set; }
        public int SalespersonPersonId { get; set; }
        public int PackedByPersonId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string CustomerPurchaseOrderNumber { get; set; }
        public bool IsCreditNote { get; set; }
        public string CreditNoteReason { get; set; }
        public string Comments { get; set; }
        public string DeliveryInstructions { get; set; }
        public string InternalComments { get; set; }
        public int TotalDryItems { get; set; }
        public int TotalChillerItems { get; set; }
        public string DeliveryRun { get; set; }
        public string RunPosition { get; set; }
        public string ReturnedDeliveryData { get; set; }
        public DateTime? ConfirmedDeliveryTime { get; set; }
        public string ConfirmedReceivedBy { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }
        public Guid TenantId { get; set; }

        public Customers BillToCustomer { get; set; }
        public Customers SalesCustomer { get; set; }
        public DeliveryMethods DeliveryMethods { get; set; }
        public Orders Orders { get; set; }
        public People AccountPerson { get; set; }
        public People LastEdited { get; set; }
        public People PackedBy { get; set; }
        public People SoldBy { get; set; }
        public People ContactPerson { get; set; }
        public ICollection<InvoiceLines> InvoiceLines { get; set; }
        public ICollection<StockItemTransactions> StockItemTransactions { get; set; }
    }
}
