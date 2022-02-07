using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_TNS.Models
{
    public class Bid
    {
        [Key]
        public string bidNumber { get; set; }
        public DateTime dateCreated { get; set; }
        public string personalAcc { get; set; }
        public Abonent Abonent { get; set; }
        public int idService { get; set; }
        public Service Service { get; set; }
        public string ServiceView { get; set; }
        public string ServiceType { get; set; }
        public string Status { get; set; }
        public string EquipmentType { get; set; }
        public string Problem { get; set; }
        public DateTime? dateClosed { get; set; }
        public string problemType { get; set; }
    }
}
