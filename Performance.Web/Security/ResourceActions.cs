using System;
using System.Collections.Generic;

namespace Performance.Models.Security
{
    public partial class ResourceActions
    {
        public int Id { get; set; }
        public string Resource { get; set; }
        public string Action { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? LastUpdatedBy { get; set; }
    }
}
