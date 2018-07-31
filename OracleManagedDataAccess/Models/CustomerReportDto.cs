using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OracleManagedDataAccess.Models
{
    public class CustomerReportDto
    {
        public string CusName { get; set; }
        public string CusFatherName { get; set; }
        public string CusMotherName { get; set; }
        public string CusPhone { get; set; }
    }
}