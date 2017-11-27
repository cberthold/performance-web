using System;
using System.Collections.Generic;

namespace Performance.Web.Imports
{
    public partial class TransactionTypes
    {
        public TransactionTypes()
        {
            StockItemTransactions = new HashSet<StockItemTransactions>();
        }

        public int TransactionTypeId { get; set; }
        public string TransactionTypeName { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public Guid TenantId { get; set; }

        public People LastEdited { get; set; }
        public ICollection<StockItemTransactions> StockItemTransactions { get; set; }
    }
}
