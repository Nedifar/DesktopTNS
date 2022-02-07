using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_TNS.Models
{
    public class Equipment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string SeriesNumber { get; set; }
        public string Name { get; set; }
        public int idEquipmentType { get; set; }
        public EquipmentType EquipmentType { get; set; }
        public List<Magistral> Magistrals { get; set; } = new List<Magistral>();
        public List<AccsessNetwork> AccsessNetworks{ get; set; } = new List<AccsessNetwork>();
        public List<AbontentEquipment> AbontentEquipments { get; set; } = new List<AbontentEquipment>();
        public bool working { get; set; }
    }
}
