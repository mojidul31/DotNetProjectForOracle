using Oracle.ManagedDataAccess.Client;
using OracleManagedDataAccess.Models;
using OracleManagedDataAccess.Models.Exceptions;
using OracleManagedDataAccess.Models.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace OracleManagedDataAccess.Repository
{
    public class CustomRepositoryImpl: ICustomRepository
    {
        private readonly DbConnection _connectionDao;

        public CustomRepositoryImpl()
        {
            _connectionDao = new DbConnection();
        }

        public bool CreateMyCustomer(Customer customer, out string errorMsg)
        {
            errorMsg = String.Empty;

            using (OracleConnection conn = _connectionDao.GetConnection())

            {
                OracleTransaction tran = null;
                try
                {
                    conn.Open();
                    tran = conn.BeginTransaction();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "MY_TEST_PACKAGE.USR_CUSTOMER_INST";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("PCUSNAME", OracleDbType.Varchar2, customer.CusName,
                            ParameterDirection.Input);
                        cmd.Parameters.Add("PCUSFATHERNAME", OracleDbType.Varchar2, customer.CusFatherName,
                            ParameterDirection.Input);
                        cmd.Parameters.Add("PCUSMOTHERNAME", OracleDbType.Varchar2, customer.CusMotherName,
                            ParameterDirection.Input);
                        cmd.Parameters.Add("PCUSPHONE", OracleDbType.Varchar2, customer.CusPhone,
                            ParameterDirection.Input);


                        OracleParameter parError = cmd.Parameters.Add("PERROR", OracleDbType.Varchar2,
                            ParameterDirection.Output);
                        parError.Size = 500;

                        cmd.ExecuteNonQuery();

                        if (parError.Status == OracleParameterStatus.Success)
                        {
                            errorMsg = $"{parError.Value}";
                        }

                    }
                    tran.Commit();
                    return errorMsg.ToUpper() == "NOERROR";
                }
#if DEBUG
                catch (OracleException oraEx)
                {
                    tran?.Rollback();
                    throw new DatabaseException(oraEx.Message, ExceptionConstants.CommonUserExceptionMessage);
                }
#endif
                catch (Exception ex)
                {
                    tran?.Rollback();
                    throw new DatabaseException(ex.Message, ExceptionConstants.CommonUserExceptionMessage);
                }

            }
        }

        public bool UpdateMyCustomer(Customer customer, out string errorMsg)
        {
            errorMsg = String.Empty;
            using (OracleConnection conn = _connectionDao.GetConnection())
            {
                OracleTransaction tran = null;
                try
                {
                    conn.Open();
                    tran = conn.BeginTransaction();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "MY_TEST_PACKAGE.USR_CUSTOMER_UPDA";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("PCUSID", OracleDbType.Int32, customer.CusId, ParameterDirection.Input);
                        cmd.Parameters.Add("PCUSNAME", OracleDbType.Varchar2, customer.CusName, ParameterDirection.Input);
                        cmd.Parameters.Add("PCUSFATHERNAME", OracleDbType.Varchar2, customer.CusFatherName,
                            ParameterDirection.Input);
                        cmd.Parameters.Add("PCUSMOTHERNAME", OracleDbType.Varchar2, customer.CusMotherName,
                            ParameterDirection.Input);
                        cmd.Parameters.Add("PCUSPHONE", OracleDbType.Varchar2, customer.CusPhone,
                            ParameterDirection.Input);

                        OracleParameter parError = cmd.Parameters.Add("PERROR", OracleDbType.Varchar2,
                            ParameterDirection.Output);
                        parError.Size = 500;

                        cmd.ExecuteNonQuery();
                        if (parError.Status == OracleParameterStatus.Success)
                        {
                            errorMsg = $"{parError.Value}";
                        }
                    }
                    tran.Commit();
                    return errorMsg.ToUpper() == "NOERROR";
                }
#if DEBUG
                catch (OracleException oraEx)
                {
                    tran?.Rollback();
                    throw new DatabaseException(oraEx.Message, ExceptionConstants.CommonUserExceptionMessage);
                }
#endif
                catch (Exception ex)
                {
                    tran?.Rollback();
                    throw new DatabaseException(ex.Message, ExceptionConstants.CommonUserExceptionMessage);
                }

            }
        }

        public bool DeleteMyCustomer(int cusId, out string errorMsg)
        {
            errorMsg = String.Empty;
            using (OracleConnection conn = _connectionDao.GetConnection())
            {
                OracleTransaction tran = null;
                try
                {
                    conn.Open();
                    tran = conn.BeginTransaction();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "MY_TEST_PACKAGE.USR_CUSTOMER_DELE";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("PCUSID", OracleDbType.Int32, cusId, ParameterDirection.Input);

                        OracleParameter parError = cmd.Parameters.Add("PERROR", OracleDbType.Varchar2,
                            ParameterDirection.Output);
                        parError.Size = 500;

                        cmd.ExecuteNonQuery();
                        if (parError.Status == OracleParameterStatus.Success)
                        {
                            errorMsg = $"{parError.Value}";
                        }
                    }
                    tran.Commit();
                    return errorMsg.ToUpper() == "NOERROR";
                }
#if DEBUG
                catch (OracleException oraEx)
                {
                    tran?.Rollback();
                    throw new DatabaseException(oraEx.Message, ExceptionConstants.CommonUserExceptionMessage);
                }
#endif
                catch (Exception ex)
                {
                    tran?.Rollback();
                    throw new DatabaseException(ex.Message, ExceptionConstants.CommonUserExceptionMessage);
                }

            }
        }

        public Customer GetCustomerById(int cusId)
        {
            DataSet ds = new DataSet();
            using (OracleConnection conn = _connectionDao.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                try
                {
                    conn.Open();
                    cmd.CommandText = "MY_TEST_PACKAGE.GET_CUSTOMER_BY_ID";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("PCUSID", OracleDbType.Int32, cusId, ParameterDirection.Input);

                    OracleParameter parRefcursor = cmd.Parameters.Add("PRC", OracleDbType.RefCursor,
                            ParameterDirection.Output);

                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(ds);
                    parRefcursor.Dispose();

                    conn.Close();


                }
#if DEBUG
                catch (OracleException oraEx)
                {
                    throw new DatabaseException(oraEx.Message, ExceptionConstants.CommonUserExceptionMessage);
                }
#endif
                catch (Exception ex)
                {
                    throw new DatabaseException(ex.Message, ExceptionConstants.CommonUserExceptionMessage);

                }


            }
            if (!ds.HaveAnyRows()) return new Customer();
            return GetCustomer(ds.Tables[0].Rows[0]);
        }

        private Customer GetCustomer(DataRow dr)
        {

            Customer aCustomer = new Customer
            {
                CusName = $"{dr["CusName"]}",
                CusFatherName = $"{dr["CusFatherName"]}",
                CusMotherName = $"{dr["CusMotherName"]}",
                CusPhone = $"{dr["CusPhone"]}"

            };
            int n;
            if (int.TryParse($"{dr["CusId"]}", out n))
                aCustomer.CusId = n;

            return aCustomer;
        }


        public List<Customer> GetAllCustomers()
        {
            List<Customer> customerList = new List<Customer>();
            DataSet ds = new DataSet();
            using (OracleConnection conn = _connectionDao.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                try
                {
                    conn.Open();
                    cmd.CommandText = "MY_TEST_PACKAGE.GET_ALL_CUSTOMERS";
                    cmd.CommandType = CommandType.StoredProcedure;

                    OracleParameter parPrefcursor = cmd.Parameters.Add("PRC", OracleDbType.RefCursor,
                        ParameterDirection.Output);

                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(ds);
                    parPrefcursor.Dispose();
                    conn.Close();
                }
#if DEBUG
                catch (OracleException oraEx)
                {
                    throw new DatabaseException(oraEx.Message, ExceptionConstants.CommonUserExceptionMessage);
                }
#endif
                catch (Exception ex)
                {
                    throw new DatabaseException(ex.Message, ExceptionConstants.CommonUserExceptionMessage);

                }


            }
            if (ds.HaveAnyRows())
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    customerList.Add(GetCustomer(ds.Tables[0].Rows[i]));
                }
            }
            else
            {
                customerList.Add(new Customer());
            }

            return customerList;
        }

        public Customer GetCustomerByPhone(string cusPhone)
        {
            DataSet ds = new DataSet();
            using (OracleConnection conn = _connectionDao.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                try
                {
                    conn.Open();
                    cmd.CommandText = "MY_TEST_PACKAGE.GET_CUSTOMER_BY_MOBILE";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("PCUSPHONE", OracleDbType.Varchar2, cusPhone, ParameterDirection.Input);

                    OracleParameter parRefcursor = cmd.Parameters.Add("PRC", OracleDbType.RefCursor,
                        ParameterDirection.Output);

                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(ds);
                    parRefcursor.Dispose();
                    conn.Close();
                }
#if DEBUG
                catch (OracleException oraEx)
                {
                    throw new DatabaseException(oraEx.Message, ExceptionConstants.CommonUserExceptionMessage);
                }
#endif
                catch (Exception ex)
                {
                    throw new DatabaseException(ex.Message, ExceptionConstants.CommonUserExceptionMessage);

                }


            }

            if (!ds.HaveAnyRows()) return new Customer();
            return GetCustomer(ds.Tables[0].Rows[0]);
        }
        public DataTable GetAllCustomersInDataTable()
        {
            //DataSet ds = new DataSet();
            DataTable table = new DataTable();
            using (OracleConnection conn = _connectionDao.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                try
                {
                    conn.Open();
                    cmd.CommandText = "MY_TEST_PACKAGE.GET_ALL_CUSTOMERS";
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    OracleParameter parPrefcursor = cmd.Parameters.Add("PRC", OracleDbType.RefCursor,
                        ParameterDirection.Output);

                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(table);
                    parPrefcursor.Dispose();
                    conn.Close();
                }
#if DEBUG
                catch (OracleException oraEx)
                {
                    throw new DatabaseException(oraEx.Message, ExceptionConstants.CommonUserExceptionMessage);
                }
#endif
                catch (Exception ex)
                {
                    throw new DatabaseException(ex.Message, ExceptionConstants.CommonUserExceptionMessage);

                }


            }
            return table;
        }

        public DataTable GetAllCustomersInDataTable(string cusName, string cusFatherName)
        {
            //DataSet ds = new DataSet();
            DataTable table = new DataTable();
            using (OracleConnection conn = _connectionDao.GetConnection())
            using (var cmd = conn.CreateCommand())
            {
                try
                {
                    conn.Open();
                    cmd.CommandText = "MY_TEST_PACKAGE.GET_ALL_CUSTOMERS_WITH_PARAMS";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("PCUSNAME", OracleDbType.Varchar2, cusName, ParameterDirection.Input);
                    cmd.Parameters.Add("PCUSFATHERNAME", OracleDbType.Varchar2, cusFatherName, ParameterDirection.Input);

                    OracleParameter parPrefcursor = cmd.Parameters.Add("PRC", OracleDbType.RefCursor,
                        ParameterDirection.Output);

                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(table);
                    parPrefcursor.Dispose();
                    conn.Close();
                }
#if DEBUG
                catch (OracleException oraEx)
                {
                    throw new DatabaseException(oraEx.Message, ExceptionConstants.CommonUserExceptionMessage);
                }
#endif
                catch (Exception ex)
                {
                    throw new DatabaseException(ex.Message, ExceptionConstants.CommonUserExceptionMessage);

                }


            }
            return table;
        }
    }
}