using OracleManagedDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OracleManagedDataAccess.Repository
{
    public interface ICustomRepository
    {
        bool CreateMyCustomer(Customer customer, out string errorMsg);
        bool UpdateMyCustomer(Customer customer, out string errorMsg);
        bool DeleteMyCustomer(int cusId, out string errorMsg);

        List<Customer> GetAllCustomers();
        Customer GetCustomerById(int cusId);
        Customer GetCustomerByPhone(string cusPhone);
    }
}