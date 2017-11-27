using System;
using System.Collections.Generic;

namespace Performance.Web.Imports
{
    public partial class Suppliers
    {
        public Suppliers()
        {
            PurchaseOrders = new HashSet<PurchaseOrders>();
            StockItemTransactions = new HashSet<StockItemTransactions>();
            StockItems = new HashSet<StockItems>();
        }

        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public int SupplierCategoryId { get; set; }
        public int PrimaryContactPersonId { get; set; }
        public int AlternateContactPersonId { get; set; }
        public int? DeliveryMethodId { get; set; }
        public int DeliveryCityId { get; set; }
        public int PostalCityId { get; set; }
        public string SupplierReference { get; set; }
        public string BankAccountName { get; set; }
        public string BankAccountBranch { get; set; }
        public string BankAccountCode { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankInternationalCode { get; set; }
        public int PaymentDays { get; set; }
        public string InternalComments { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string WebsiteUrl { get; set; }
        public string DeliveryAddressLine1 { get; set; }
        public string DeliveryAddressLine2 { get; set; }
        public string DeliveryPostalCode { get; set; }
        public string PostalAddressLine1 { get; set; }
        public string PostalAddressLine2 { get; set; }
        public string PostalPostalCode { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public Guid TenantId { get; set; }

        public Cities Cities { get; set; }
        public Cities CitiesNavigation { get; set; }
        public DeliveryMethods DeliveryMethods { get; set; }
        public People People { get; set; }
        public People PrimaryContact { get; set; }
        public People LastEdited { get; set; }
        public SupplierCategories SupplierCategories { get; set; }
        public ICollection<PurchaseOrders> PurchaseOrders { get; set; }
        public ICollection<StockItemTransactions> StockItemTransactions { get; set; }
        public ICollection<StockItems> StockItems { get; set; }
    }
}
