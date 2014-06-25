using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTM
{
    class SoortMeting
    {
        public int Id {get; set;}
        public string Naam { get; set; }

        public SoortMeting(int SoortMetingId, string SoortMeting)
        {
            this.Id = SoortMetingId;
            this.Naam = SoortMeting;
        }
    }
}
