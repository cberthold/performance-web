using System;
using System.Collections.Generic;

namespace Performance.Web.Imports
{
    public partial class Orders
    {
        public Orders()
        {
            InverseOrdersNavigation = new HashSet<Orders>();
            Invoices = new HashSet<Invoices>();
            OrderLines = new HashSet<OrderLines>();
        }

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int SalespersonPersonId { get; set; }
        public int? PickedByPersonId { get; set; }
        public int ContactPersonId { get; set; }
        public int? BackorderOrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }
        public string CustomerPurchaseOrderNumber { get; set; }
        public bool IsUndersupplyBackordered { get; set; }
        public string Comments { get; set; }
        public string DeliveryInstructions { get; set; }
        public string InternalComments { get; set; }
        public DateTime? PickingCompletedWhen { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }
        public Guid TenantId { get; set; }

        public Customers Customers { get; set; }
        public Orders OrdersNavigation { get; set; }
        public People ContactPerson { get; set; }
        public People PickedBy { get; set; }
        public People SalesPerson { get; set; }
        public People LastEdited { get; set; }
        public ICollection<Orders> InverseOrdersNavigation { get; set; }
        public ICollection<Invoices> Invoices { get; set; }
        public ICollection<OrderLines> OrderLines { get; set; }
    }
}
