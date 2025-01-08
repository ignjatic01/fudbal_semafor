using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalSemafor.Models
{
    public class IgracStatistika
    {
        public int IgracId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Klub { get; set; }
        public int BrojGolova { get; set; }
        public int BrojZutihKartona { get; set; }
        public int BrojCrvenihKartona { get; set; }
    }
}
