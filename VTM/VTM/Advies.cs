using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VTM {
    public class Advies {
        public int Id { get; set; }
        public string Omschrijving { get; set; }

        public Advies(int Id, string Omschrijving) {
            this.Id = Id;
            this.Omschrijving = Omschrijving;
        }
    }
}
