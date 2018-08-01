using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OracleManagedDataAccess.Models;
using OracleManagedDataAccess.Repository;
using System.Data;

namespace OracleManagedDataAccess.Service
{
    public class CustomServiceImpl : ICustomService
    {
        private readonly ICustomRepository _customRepository;
        public CustomServiceImpl()
        {
            _customRepository = new CustomRepositoryImpl();
        }
        public bool CreateMyCustomer(Customer customer, out string clientErrMsg)
        {
            return _customRepository.CreateMyCustomer(customer, out clientErrMsg);

        }
        public bool UpdateMyCustomer(Customer customer, out string clientErrMsg)
        {
            return _customRepository.UpdateMyCustomer(customer, out clientErrMsg);
        }
        public bool DeleteMyCustomer(int cusId, out string errorMsg)
        {
            return _customRepository.DeleteMyCustomer(cusId, out errorMsg);
        }
        public Customer GetCustomerById(int cusId)
        {
            return _customRepository.GetCustomerById(cusId);
        }
        public List<Customer> GetAllCustomers()
        {
            return _customRepository.GetAllCustomers();
        }
        public Customer GetEmptyCustomerInfo()
        {
            return new Customer();
        }

        public Customer GetCustomerByMobile(string cusPhone)
        {
            return _customRepository.GetCustomerByPhone(cusPhone);
        }
        public DataTable GetAllCustomersInDataTable()
        {
           return _customRepository.GetAllCustomersInDataTable();
        }

        public DataTable GetAllCustomersInDataTable(string cusName, string cusFatherName)
        {
            try
            {
                return _customRepository.GetAllCustomersInDataTable(cusName, cusFatherName);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }
    }
}