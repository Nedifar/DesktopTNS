using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_TNS.Models
{
    public class AbontentEquipment
    {
        [Key]
        public int idAbontentEquipment {get; set;}
        public int idEquipment { get; set; }
        public Equipment Equipment { get; set; }
        public string ports { get; set; }
        public string networkStandart { get; set; }
        public string speed { get; set; }
        public List<Abonent> Abonents { get; set; } = new List<Abonent>();
    }
}
