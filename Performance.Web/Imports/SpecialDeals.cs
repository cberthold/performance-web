using System;
using System.Collections.Generic;

namespace Performance.Web.Imports
{
    public partial class SpecialDeals
    {
        public int SpecialDealId { get; set; }
        public int? StockItemId { get; set; }
        public int? CustomerId { get; set; }
        public int? BuyingGroupId { get; set; }
        public int? CustomerCategoryId { get; set; }
        public int? StockGroupId { get; set; }
        public string DealDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? DiscountPercentage { get; set; }
        public decimal? UnitPrice { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }
        public Guid TenantId { get; set; }

        public BuyingGroups BuyingGroups { get; set; }
        public CustomerCategories CustomerCategories { get; set; }
        public Customers Customers { get; set; }
        public People People { get; set; }
        public StockGroups StockGroups { get; set; }
        public StockItems StockItems { get; set; }
    }
}
