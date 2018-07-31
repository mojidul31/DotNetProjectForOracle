using OracleManagedDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace OracleManagedDataAccess.Service
{
    public interface ICustomService
    {
        bool CreateMyCustomer(Customer customer, out string clientErrMsg);

        bool UpdateMyCustomer(Customer customer, out string clientErrMsg);
        bool DeleteMyCustomer(int cusId, out string errorMsg);

        Customer GetCustomerById(int cusId);

        List<Customer> GetAllCustomers();
        Customer GetEmptyCustomerInfo();
        Customer GetCustomerByMobile(string cusPhone);
        DataTable GetAllCustomersInDataTable();
    }
}