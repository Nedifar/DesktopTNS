using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_TNS.Models
{
    public class Service
    {
        [Key]
        public int idService { get; set; }
        public string Name { get; set; }
        public List<Abonent> Abonents { get; set; } = new List<Abonent>();
        public List<Bid> Bids { get; set; } = new List<Bid>();
    }
}
