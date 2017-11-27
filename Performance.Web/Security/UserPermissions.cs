using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Performance.Models.Security
{
    public class UserPermissions
    {
        public long PolicyId { get; set; }
        public long? ParentPolicyId { get; set; }
        public string Name { get; set; }
        public int FeatureId { get; set; }
        public string FeatureName { get; set; }
        public int? FeatureTypeId { get; set; }
        public string FeatureTypeName { get; set; }
        public bool ParentAllowed { get; set; }
        public bool? CurrentAllowed { get; set; }
        public bool Allowed { get; set; }
        public int Level { get; set; }
        public string Type { get; set; }
        public Guid? UserId { get; set; }
        public Guid? TenantId { get; set; }
    }
}
