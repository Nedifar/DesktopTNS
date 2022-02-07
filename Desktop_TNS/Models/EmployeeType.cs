using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_TNS.Models
{
    public class EmployeeType
    {
        [Key]
        public int idEmployeeType { get; set; }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public List<EmployeeInfo> EmployeeInfos { get; set; } = new List<EmployeeInfo>();
    }
}
