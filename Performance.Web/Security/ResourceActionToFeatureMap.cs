using System;
using System.Collections.Generic;

namespace Performance.Models.Security
{
    public partial class ResourceActionToFeatureMap
    {
        public int ResourceActionId { get; set; }
        public int FeatureId { get; set; }

        public Features Feature { get; set; }
    }
}
