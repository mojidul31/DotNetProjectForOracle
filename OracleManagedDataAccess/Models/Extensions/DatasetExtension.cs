using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace OracleManagedDataAccess.Models.Extensions
{
    public static class DatasetExtension
    {
        public static bool HaveAnyRows(this DataSet obj)
        {
            return obj?.Tables.Count > 0 && obj.Tables[0].Rows.Count > 0;
        }
        public static DataRow GetFirstRowOfFirstTable(this DataSet obj)
        {
            return obj?.Tables[0].Rows[0];
        }
    }
}