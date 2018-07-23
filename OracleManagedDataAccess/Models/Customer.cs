using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OracleManagedDataAccess.Models
{
    public class Customer
    {
        public int? CusId { get; set; }
        [Display(Name = "Customer Name")]
        [StringLength(100, ErrorMessage = "Customer name should not be too long")]
        [Required(ErrorMessage = "Customer Name is required!")]
        public string CusName { get; set; }
        [Display(Name = "Father Name")]
        [Required(ErrorMessage = "Customer Father Name is required!")]
        public string CusFatherName { get; set; }
        [Display(Name = "Mother Name")]
        [Required(ErrorMessage = "Customer Mother Name is required!")]
        public string CusMotherName { get; set; }
        [Display(Name = "Mobile No")]
        [Required(ErrorMessage = "Mobile Number is required!")]
        [RegularExpression(@"^(\d{11})$", ErrorMessage = "Mobile number must be of 11 digits, and without regional code")]
        public string CusPhone { get; set; }
    }
}