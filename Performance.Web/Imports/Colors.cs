using System;
using System.Collections.Generic;

namespace Performance.Web.Imports
{
    public partial class Colors
    {
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public Guid TenantId { get; set; }

        public People LastEdited { get; set; }
    }
}
