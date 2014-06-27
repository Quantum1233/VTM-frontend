using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VTM
{
    class Regio
    {
        public int Id { get; set; }
        public string Naam { get; set; }

        public Regio(int Id, string Naam)
        {
            this.Id = Id;
            this.Naam = Naam;
        }
    }
}
