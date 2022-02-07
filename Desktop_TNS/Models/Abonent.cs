using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_TNS.Models
{
    public class Abonent
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string AbonentNumber { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string midlleName { get; set; }
        public string gender { get; set; }
        public DateTime? date { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string AddressPropiski { get; set; }
        public string AddressNumber { get; set; }
        public Address Address { get; set; }
        public string passport_s { get; set; }
        public string passport_n { get; set; }
        public string code { get; set; }
        public string Issued { get; set; }
        public DateTime? IssuedDate { get; set; }
        public string ContractNumber { get; set; }
        public DateTime? dateСonclusion { get; set; }
        public string ContractType { get; set; }
        public string reasonContract { get; set; }
        public string personalAcc { get; set; }
        public List<Service> Services { get; set; } = new List<Service>();
        public DateTime? dateRastor { get; set; }
        public string SeriesNumber { get; set; }
        public int? idAbontentEquipment { get; set; }
        public AbontentEquipment AbontentEquipment { get; set; }
        public string getList
        {
            get
            {
                string ret = "";
                foreach (var l in Services)
                    ret += l.Name + " ";
                return ret;
            }
        }
        public List<Bid> Bids { get; set; } = new List<Bid>();
    }
}
