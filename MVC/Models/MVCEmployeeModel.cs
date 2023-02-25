using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class MVCEmployeeModel
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage ="This Feild Is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This Feild Is Required")]
        public string Position { get; set; }
        [Required(ErrorMessage = "This Feild Is Required")]
        public Nullable<int> Age { get; set; }
        [Required(ErrorMessage = "This Feild Is Required")]
        public Nullable<int> Salary { get; set; }
    }
}