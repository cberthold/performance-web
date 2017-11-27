using System;
using System.Collections.Generic;

namespace Performance.Models.Security
{
    public partial class AdminUserPolicy
    {
        public long PolicyId { get; set; }
        public Guid UserId { get; set; }

        public Policy Policy { get; set; }
    }
}
