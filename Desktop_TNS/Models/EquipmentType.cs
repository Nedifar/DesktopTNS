using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_TNS.Models
{
    public class EquipmentType
    {
        [Key]
        public int idEquipmentType { get; set; }
        public string Name { get; set; }
        public List<Equipment> Equipment { get; set; } = new List<Equipment>();
    }
}
