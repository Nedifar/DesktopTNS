using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_TNS.Models
{
    public class EmployeeInfo
    {
        [Key]
        public int idEmployeeInfo { get; set; }
        public string info { get; set; }
        public DateTime time { get; set; }
        public int idEmployeeType { get; set; }
        public EmployeeType EmployeeType { get; set; }
    }
}
