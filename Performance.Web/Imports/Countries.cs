﻿using System;
using System.Collections.Generic;

namespace Performance.Web.Imports
{
    public partial class Countries
    {
        public Countries()
        {
            StateProvinces = new HashSet<StateProvinces>();
        }

        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string FormalName { get; set; }
        public string IsoAlpha3Code { get; set; }
        public int? IsoNumericCode { get; set; }
        public string CountryType { get; set; }
        public long? LatestRecordedPopulation { get; set; }
        public string Continent { get; set; }
        public string Region { get; set; }
        public string Subregion { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public Guid TenantId { get; set; }

        public People LastEdited { get; set; }
        public ICollection<StateProvinces> StateProvinces { get; set; }
    }
}
