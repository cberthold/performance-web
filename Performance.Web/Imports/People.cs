using System;
using System.Collections.Generic;

namespace Performance.Web.Imports
{
    public partial class People
    {
        public People()
        {
            BuyingGroups = new HashSet<BuyingGroups>();
            Cities = new HashSet<Cities>();
            Colors = new HashSet<Colors>();
            Countries = new HashSet<Countries>();
            CustomerCategories = new HashSet<CustomerCategories>();
            CustomersPeople = new HashSet<Customers>();
            PrimaryContactCustomers = new HashSet<Customers>();
            CustomersPeopleNavigation = new HashSet<Customers>();
            DeliveryMethods = new HashSet<DeliveryMethods>();
            InversePeopleNavigation = new HashSet<People>();
            LastEditedInvoiceLines = new HashSet<InvoiceLines>();
            InvoicesForAccount = new HashSet<Invoices>();
            LastEditedInvoices = new HashSet<Invoices>();
            PackedInvoices = new HashSet<Invoices>();
            SoldInvoices = new HashSet<Invoices>();
            InvoicesPeopleNavigation = new HashSet<Invoices>();
            OrderLines = new HashSet<OrderLines>();
            OrdersPeople = new HashSet<Orders>();
            PickedOrders = new HashSet<Orders>();
            OrdersSold = new HashSet<Orders>();
            OrdersPeopleNavigation = new HashSet<Orders>();
            PackageTypes = new HashSet<PackageTypes>();
            PaymentMethods = new HashSet<PaymentMethods>();
            PurchaseOrderLines = new HashSet<PurchaseOrderLines>();
            PurchaseOrdersPeople = new HashSet<PurchaseOrders>();
            PurchaseOrdersPeopleNavigation = new HashSet<PurchaseOrders>();
            SpecialDeals = new HashSet<SpecialDeals>();
            StateProvinces = new HashSet<StateProvinces>();
            StockGroups = new HashSet<StockGroups>();
            StockItemHoldings = new HashSet<StockItemHoldings>();
            StockItemStockGroups = new HashSet<StockItemStockGroups>();
            StockItemTransactions = new HashSet<StockItemTransactions>();
            StockItems = new HashSet<StockItems>();
            SupplierCategories = new HashSet<SupplierCategories>();
            SuppliersPeople = new HashSet<Suppliers>();
            SuppliersPeople1 = new HashSet<Suppliers>();
            SuppliersPeopleNavigation = new HashSet<Suppliers>();
            SystemParameters = new HashSet<SystemParameters>();
            TransactionTypes = new HashSet<TransactionTypes>();
        }

        public int PersonId { get; set; }
        public string FullName { get; set; }
        public string PreferredName { get; set; }
        public string SearchName { get; set; }
        public bool IsPermittedToLogon { get; set; }
        public string LogonName { get; set; }
        public bool IsExternalLogonProvider { get; set; }
        public byte[] HashedPassword { get; set; }
        public bool IsSystemUser { get; set; }
        public bool IsEmployee { get; set; }
        public bool IsSalesperson { get; set; }
        public string UserPreferences { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string EmailAddress { get; set; }
        public byte[] Photo { get; set; }
        public string CustomFields { get; set; }
        public string OtherLanguages { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public Guid TenantId { get; set; }

        public People PeopleNavigation { get; set; }
        public ICollection<BuyingGroups> BuyingGroups { get; set; }
        public ICollection<Cities> Cities { get; set; }
        public ICollection<Colors> Colors { get; set; }
        public ICollection<Countries> Countries { get; set; }
        public ICollection<CustomerCategories> CustomerCategories { get; set; }
        public ICollection<Customers> CustomersPeople { get; set; }
        public ICollection<Customers> PrimaryContactCustomers { get; set; }
        public ICollection<Customers> CustomersPeopleNavigation { get; set; }
        public ICollection<DeliveryMethods> DeliveryMethods { get; set; }
        public ICollection<People> InversePeopleNavigation { get; set; }
        public ICollection<InvoiceLines> LastEditedInvoiceLines { get; set; }
        public ICollection<Invoices> InvoicesForAccount { get; set; }
        public ICollection<Invoices> LastEditedInvoices { get; set; }
        public ICollection<Invoices> PackedInvoices { get; set; }
        public ICollection<Invoices> SoldInvoices { get; set; }
        public ICollection<Invoices> InvoicesPeopleNavigation { get; set; }
        public ICollection<OrderLines> OrderLines { get; set; }
        public ICollection<Orders> OrdersPeople { get; set; }
        public ICollection<Orders> PickedOrders { get; set; }
        public ICollection<Orders> OrdersSold { get; set; }
        public ICollection<Orders> OrdersPeopleNavigation { get; set; }
        public ICollection<PackageTypes> PackageTypes { get; set; }
        public ICollection<PaymentMethods> PaymentMethods { get; set; }
        public ICollection<PurchaseOrderLines> PurchaseOrderLines { get; set; }
        public ICollection<PurchaseOrders> PurchaseOrdersPeople { get; set; }
        public ICollection<PurchaseOrders> PurchaseOrdersPeopleNavigation { get; set; }
        public ICollection<SpecialDeals> SpecialDeals { get; set; }
        public ICollection<StateProvinces> StateProvinces { get; set; }
        public ICollection<StockGroups> StockGroups { get; set; }
        public ICollection<StockItemHoldings> StockItemHoldings { get; set; }
        public ICollection<StockItemStockGroups> StockItemStockGroups { get; set; }
        public ICollection<StockItemTransactions> StockItemTransactions { get; set; }
        public ICollection<StockItems> StockItems { get; set; }
        public ICollection<SupplierCategories> SupplierCategories { get; set; }
        public ICollection<Suppliers> SuppliersPeople { get; set; }
        public ICollection<Suppliers> SuppliersPeople1 { get; set; }
        public ICollection<Suppliers> SuppliersPeopleNavigation { get; set; }
        public ICollection<SystemParameters> SystemParameters { get; set; }
        public ICollection<TransactionTypes> TransactionTypes { get; set; }
    }
}
