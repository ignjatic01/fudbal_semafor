using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalSemafor.Models
{
    public class KlubStatistika
    {
        public int IdKlub {  get; set; }
        public string Naziv { get; set; }
        public string Grad {  get; set; }
        public int BrojUtakmica { get; set; }
        public int BrojPobjeda { get; set; }
        public int BrojNerijesenih {  get; set; }
        public int BrojPoraza { get; set; }
    }
}
