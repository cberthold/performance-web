using System;
using System.Collections.Generic;

namespace Performance.Web.Imports
{
    public partial class PaymentMethods
    {
        public int PaymentMethodId { get; set; }
        public string PaymentMethodName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public Guid TenantId { get; set; }

        public People People { get; set; }
    }
}
