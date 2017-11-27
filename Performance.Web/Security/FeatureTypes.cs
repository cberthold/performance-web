using System;
using System.Collections.Generic;

namespace Performance.Models.Security
{
    public partial class FeatureTypes
    {
        public FeatureTypes()
        {
            FeatureTypePolicy = new HashSet<FeatureTypePolicy>();
            Features = new HashSet<Features>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<FeatureTypePolicy> FeatureTypePolicy { get; set; }
        public ICollection<Features> Features { get; set; }
    }
}
