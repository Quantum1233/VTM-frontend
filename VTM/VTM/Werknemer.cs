using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VTM {
    public class Werknemer {
        public int Id { get; set; }
        public string Naam { get; set; }

        public Werknemer(int Id, string Naam) {
            this.Id = Id;
            this.Naam = Naam;
        }
    }
}
