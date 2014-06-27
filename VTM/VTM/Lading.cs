using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTM
{
    public class Lading
    {
        public int Id { get; set; }
        public string Naam { get; set; }

        public Lading(int LadingId, string LadingNaam) {
            this.Id = LadingId;
            this.Naam = LadingNaam;
        }
    }
}
