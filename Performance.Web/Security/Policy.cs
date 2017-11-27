using System;
using System.Collections.Generic;

namespace Performance.Models.Security
{
    public partial class Policy
    {
        public Policy()
        {
            FeatureTypePolicy = new HashSet<FeatureTypePolicy>();
            InverseParentPolicy = new HashSet<Policy>();
            PolicyFeaturePermissions = new HashSet<PolicyFeaturePermissions>();
        }

        public long Id { get; set; }
        public Guid LookupId { get; set; }
        public long? ParentPolicyId { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? LastUpdatedBy { get; set; }

        public Policy ParentPolicy { get; set; }
        public AdminUserPolicy AdminUserPolicy { get; set; }
        public UserTenantPolicy UserTenantPolicy { get; set; }
        public ICollection<FeatureTypePolicy> FeatureTypePolicy { get; set; }
        public ICollection<Policy> InverseParentPolicy { get; set; }
        public ICollection<PolicyFeaturePermissions> PolicyFeaturePermissions { get; set; }
    }
}
