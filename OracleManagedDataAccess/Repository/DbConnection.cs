using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace OracleManagedDataAccess.Repository
{
    public class DbConnection
    {
        public OracleConnection GetConnection()
        {
            string connectionString =
                WebConfigurationManager.ConnectionStrings["MyOracleConnectionString"].ConnectionString;
            OracleConnection connection = new OracleConnection(connectionString);
            //connection.ConnectionString = connectionString;
            return connection;
        }
    }
}