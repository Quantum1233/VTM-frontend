using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTM
{
    class LocatieMeting
    {
        public int Id {get; set;}
        public string Naam { get; set; }

        public LocatieMeting(int LocatieMetingId, string LocatieMeting)
        {
            this.Id = LocatieMetingId;
            this.Naam = LocatieMeting;
        }
    }
}
