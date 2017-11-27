using System;
using System.Collections.Generic;

namespace Performance.Models.Security
{
    public partial class Tenants
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
