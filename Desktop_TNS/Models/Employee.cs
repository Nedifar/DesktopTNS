using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_TNS.Models
{
    public class Employee
    {
        [Key]
        public string idEmployee { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string midllName { get; set; }
        public int idEmployeeType { get; set; }
        public EmployeeType EmployeeType { get; set; }
    }
}
