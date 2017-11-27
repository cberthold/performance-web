using System;
using System.Collections.Generic;

namespace Performance.Models.Security
{
    public partial class PolicyFeaturePermissions
    {
        public long Id { get; set; }
        public Guid LookupId { get; set; }
        public long PolicyId { get; set; }
        public int FeatureId { get; set; }
        public bool? Allowed { get; set; }

        public Features Feature { get; set; }
        public Policy Policy { get; set; }
    }
}
