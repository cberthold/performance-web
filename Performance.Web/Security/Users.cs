using System;
using System.Collections.Generic;

namespace Performance.Models.Security
{
    public partial class Users
    {
        public Users()
        {
            UserTenantPolicy = new HashSet<UserTenantPolicy>();
        }

        public Guid Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Salt { get; set; }
        public string Password { get; set; }
        public bool? IsActive { get; set; }

        public ICollection<UserTenantPolicy> UserTenantPolicy { get; set; }
    }
}
