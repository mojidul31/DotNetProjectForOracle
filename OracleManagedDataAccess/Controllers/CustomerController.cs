using OracleManagedDataAccess.Models;
using OracleManagedDataAccess.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OracleManagedDataAccess.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomService _customService = new CustomServiceImpl();
        // GET: Customer
        public ActionResult Index()
        {
            var customerList = _customService.GetAllCustomers();
            CustomerList _customerList = new CustomerList();

            _customerList.Customers = _customService.GetAllCustomers();
            return View(_customerList);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string Msg;
                    string confirmMsg = "Customer Save sucessfully";
                    //string showMsg = "Insert Customer Successfully!";
                    bool response = _customService.CreateMyCustomer(model, out Msg);
                    if (response)
                    {
                        ModelState.Clear();
                        if (Msg == "NOERROR")
                        {
                            ViewBag.msgShow = confirmMsg;
                        }
                    }
                    return View();
                }
                return View(model);

                //return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {

            Customer customer = _customService.GetCustomerById(id);
            if (customer != null)
            {
                return View(customer);
            }

            return View();

        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            try
            {
                string Msg;
                string showMsg = "Customer Updated Successfully!";
                bool response = _customService.UpdateMyCustomer(customer, out Msg);
                if (response)
                {
                    if (Msg == "NOERROR")
                    {
                        ViewBag.msgShow = showMsg;
                        return RedirectToAction("Index");
                    }

                }
                ViewBag.msgShow = Msg;
                return View();
            }
            catch
            {
                //ViewBag.msgShow = clientErrMsg;
                return View();
            }

        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            Customer customer = _customService.GetCustomerById(id);
            if (customer != null)
            {
                return View(customer);
            }

            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        //public ActionResult Delete(int cusId, Customer model)
        public ActionResult Delete(Customer model)
        {
            try
            {
                int id = Convert.ToInt32(model.CusId);
                string Msg;
                string showMsg = "Customer Deleted Successfully!";
                bool response = _customService.DeleteMyCustomer(id, out Msg);
                //SetMesageHandler(response, showMsg, Msg);
                if (response)
                {
                    if (Msg == "NOERROR")
                    {
                        ViewBag.msgShow = showMsg;
                        return RedirectToAction("Index");
                    }

                }
                ViewBag.msgShow = Msg;
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}