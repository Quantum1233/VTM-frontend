using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VTM {
    public class Resultaat {
        public int Id { get; set; }
        public string ResultaatNaam { get; set; }

        public Resultaat(int Id, string Resultaat) {
            this.Id = Id;
            this.ResultaatNaam = Resultaat;
        }
    }
}
