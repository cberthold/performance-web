using System;
using System.Collections.Generic;

namespace Performance.Web.Imports
{
    public partial class SupplierCategories
    {
        public SupplierCategories()
        {
            Suppliers = new HashSet<Suppliers>();
        }

        public int SupplierCategoryId { get; set; }
        public string SupplierCategoryName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public Guid TenantId { get; set; }

        public People LastEdited { get; set; }
        public ICollection<Suppliers> Suppliers { get; set; }
    }
}
