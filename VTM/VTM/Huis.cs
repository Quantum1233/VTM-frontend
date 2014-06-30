using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTM {
    class Huis {
        public int aantalKamers { get ; set; }
        public string straat { get; set; }
        public bool tuin { get; set; }
        public int dagenOnline { get; set; }

        public Huis(int aantalKamers, string straat, bool tuin) {
            dagenOnline = 0;
            this.aantalKamers = aantalKamers;
            this.straat = straat;
            this.tuin = tuin;
        }
    }
}
