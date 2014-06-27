using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTM
{
    class Opdrachtgever
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public double Prijs { get; set; }
        private List<Supplier> suppliers;
        public List<Supplier> Suppliers { get { return suppliers; } }
        private List<Locatie> locaties;
        public List<Locatie> Locaties { get { return locaties; } }

        public Opdrachtgever(int OpdrachtgeverId, string Naam)
        {
            this.Id = OpdrachtgeverId;
            this.Naam = Naam;
            suppliers = new List<Supplier>();
            locaties = new List<Locatie>();
            //this.Prijs = Prijs;
        }
    }
}
