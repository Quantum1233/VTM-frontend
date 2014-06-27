using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTM
{
    class Locatie
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public Regio Regio { get; set; }
        public int OpdrachtgeverId {get; set;}

        public Locatie(int Id, string Naam, Regio Regio, int OpdrachtgeverId) {
            this.Id = Id;
            this.Naam = Naam;
            this.Regio = Regio;
            this.OpdrachtgeverId = OpdrachtgeverId;
        }
    }
}
