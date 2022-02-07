using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_TNS.Models
{
    public class District
    {
        [Key]
        public int idDistrict { get; set; }
        public string Name { get; set; }
        public double Area { get; set; }
        public int Population { get; set; }
        public int StationCount { get; set; }
        public string BuildType { get; set; }
    }
}
