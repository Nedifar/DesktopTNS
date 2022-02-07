using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_TNS.Models
{
    public class Magistral
    {
        [Key]
        public int id_Magistral { get; set; }
        public int idEquipment { get; set; }
        public Equipment Equipment { get; set; }
        public double Frequince { get; set; }
        public string Damping { get; set; }
        public string dataTechnlogy { get; set; }
        public List<Location> Locations { get; set; } = new List<Location>();
    }
}
