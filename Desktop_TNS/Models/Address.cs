using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_TNS.Models
{
    public class Address
    {
        [Key]
        public string AddressNumber { get; set; }
        public string prefixCode { get; set; }
        public string Raion { get; set; }
        public string prefix { get; set; }
        public string house { get; set; }
        public List<Abonent> Abonents { get; set; } = new List<Abonent>();
    }
}
