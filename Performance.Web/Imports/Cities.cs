using System;
using System.Collections.Generic;

namespace Performance.Web.Imports
{
    public partial class Cities
    {
        public Cities()
        {
            CustomersCities = new HashSet<Customers>();
            CustomersCitiesNavigation = new HashSet<Customers>();
            SuppliersCities = new HashSet<Suppliers>();
            SuppliersCitiesNavigation = new HashSet<Suppliers>();
            SystemParametersCities = new HashSet<SystemParameters>();
            SystemParametersCitiesNavigation = new HashSet<SystemParameters>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateProvinceId { get; set; }
        public long? LatestRecordedPopulation { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public Guid TenantId { get; set; }

        public People People { get; set; }
        public StateProvinces StateProvinces { get; set; }
        public ICollection<Customers> CustomersCities { get; set; }
        public ICollection<Customers> CustomersCitiesNavigation { get; set; }
        public ICollection<Suppliers> SuppliersCities { get; set; }
        public ICollection<Suppliers> SuppliersCitiesNavigation { get; set; }
        public ICollection<SystemParameters> SystemParametersCities { get; set; }
        public ICollection<SystemParameters> SystemParametersCitiesNavigation { get; set; }
    }
}
