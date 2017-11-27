using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace System
{
    public static class TenantExtensions
    {
        public static SqlParameter ToTenantSqlParameter(this Guid tenantId, string paramName)
        {
            var table = tenantId.ToTenantTable();
            var parameter = new SqlParameter(paramName, SqlDbType.Structured)
            {
                Value = table,
            };
            return parameter;
        }

        public static SqlParameter ToTenantSqlParameter(this IEnumerable<Guid> tenantIds, string paramName)
        {
            var table = tenantIds.ToTenantTable();
            var parameter = new SqlParameter(paramName, SqlDbType.Structured)
            {
                Value = table,
            };
            return parameter;
        }

        public static DataTable ToTenantTable(this IEnumerable<Guid> tenantIds)
        {
            var table = BuildDataTable();
            foreach (var tenantId in tenantIds)
            {
                AddTenant(table, tenantId);
            }
            return table;
        }

        public static DataTable ToTenantTable(this Guid tenantId)
        {
            var table = BuildDataTable();
            AddTenant(table, tenantId);
            return table;
        }

        private static void AddTenant(DataTable table, Guid tenantId)
        {
            var row = table.NewRow();
            row["TenantId"] = tenantId;
            table.Rows.Add(row);
        }

        private static DataTable BuildDataTable()
        {
            var table = new DataTable();
            table.Columns.Add("TenantId", typeof(Guid));
            return table;
        }
    }
}
