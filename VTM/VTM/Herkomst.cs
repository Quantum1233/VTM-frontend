using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTM
{
    public class Herkomst
    {
        public int Id { get; set; }
        public string Naam { get; set; }

        public Herkomst(int HerkomstId, string HerkomstNaam)
        {
            this.Id = HerkomstId;
            this.Naam = HerkomstNaam;
        }
    }
}
