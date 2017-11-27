using System;
using System.Collections.Generic;

namespace Performance.Models.Security
{
    public partial class FeatureTypePolicy
    {
        public long PolicyId { get; set; }
        public int FeatureTypeId { get; set; }

        public FeatureTypes FeatureType { get; set; }
        public Policy Policy { get; set; }
    }
}
