using System;
using System.Collections.Generic;

namespace Performance.Web.Imports
{
    public partial class Customers
    {
        public Customers()
        {
            InverseCustomersNavigation = new HashSet<Customers>();
            BillToInvoices = new HashSet<Invoices>();
            SalesInvoices = new HashSet<Invoices>();
            Orders = new HashSet<Orders>();
            SpecialDeals = new HashSet<SpecialDeals>();
            StockItemTransactions = new HashSet<StockItemTransactions>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int BillToCustomerId { get; set; }
        public int CustomerCategoryId { get; set; }
        public int? BuyingGroupId { get; set; }
        public int PrimaryContactPersonId { get; set; }
        public int? AlternateContactPersonId { get; set; }
        public int DeliveryMethodId { get; set; }
        public int DeliveryCityId { get; set; }
        public int PostalCityId { get; set; }
        public decimal? CreditLimit { get; set; }
        public DateTime AccountOpenedDate { get; set; }
        public decimal StandardDiscountPercentage { get; set; }
        public bool IsStatementSent { get; set; }
        public bool IsOnCreditHold { get; set; }
        public int PaymentDays { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string DeliveryRun { get; set; }
        public string RunPosition { get; set; }
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

        public BuyingGroups BuyingGroups { get; set; }
        public Cities DeliveredTo { get; set; }
        public Cities CustomerCity { get; set; }
        public CustomerCategories CustomerCategories { get; set; }
        public Customers BillToCustomer { get; set; }
        public DeliveryMethods DeliveryMethods { get; set; }
        public People AlternateContact { get; set; }
        public People PrimaryContact { get; set; }
        public People LastEdited { get; set; }
        public ICollection<Customers> InverseCustomersNavigation { get; set; }
        public ICollection<Invoices> BillToInvoices { get; set; }
        public ICollection<Invoices> SalesInvoices { get; set; }
        public ICollection<Orders> Orders { get; set; }
        public ICollection<SpecialDeals> SpecialDeals { get; set; }
        public ICollection<StockItemTransactions> StockItemTransactions { get; set; }
    }
}
