using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_TNS.Models
{
    public class AccsessNetwork
    {
        [Key]
        public int idAccsessNetwork { get; set; }
        public int idEquipment { get; set; }
        public Equipment Equipment { get; set; }
        public int ports { get; set; }
        public string networkStandart { get; set; }
        public string Frequince { get; set; }
        public string Interface { get; set; }
        public string speed { get; set; }
        public string Location { get; set; }
    }
}
