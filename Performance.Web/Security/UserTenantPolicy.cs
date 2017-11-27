using System;
using System.Collections.Generic;

namespace Performance.Models.Security
{
    public partial class UserTenantPolicy
    {
        public long PolicyId { get; set; }
        public Guid UserId { get; set; }
        public Guid TenantId { get; set; }

        public Policy Policy { get; set; }
        public Users User { get; set; }
    }
}
