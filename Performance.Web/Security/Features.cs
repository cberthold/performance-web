using System;
using System.Collections.Generic;

namespace Performance.Models.Security
{
    public partial class Features
    {
        public Features()
        {
            PolicyFeaturePermissions = new HashSet<PolicyFeaturePermissions>();
            ResourceActionToFeatureMap = new HashSet<ResourceActionToFeatureMap>();
        }

        public int Id { get; set; }
        public Guid LookupId { get; set; }
        public int FeatureGroupId { get; set; }
        public int FeatureTypeId { get; set; }
        public string Name { get; set; }
        public string LegacyTextId { get; set; }
        public int? LegacyEventId { get; set; }
        public bool? Enabled { get; set; }
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? LastUpdatedBy { get; set; }

        public FeatureTypes FeatureType { get; set; }
        public ICollection<PolicyFeaturePermissions> PolicyFeaturePermissions { get; set; }
        public ICollection<ResourceActionToFeatureMap> ResourceActionToFeatureMap { get; set; }
    }
}
