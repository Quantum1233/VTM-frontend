using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTM {
    public class Meting {
        public int MetingId { get; set; }
        public DateTime Datum { get; set; }
        public DateTime Tijd { get; set; }
        public int Temperatuur { get; set; }
        public string Fyconummer { get; set; }
        public string Ordernummer { get; set; }
        public Container Container { get; set; }
        public Werknemer Werknemer { get; set; }
        public Resultaat Resultaat { get; set; }
        public Advies Advies { get; set; }
        public Opdrachtgever Opdrachtgever { get; set; }
        public Locatie Locatie { get; set; }
        public Lading Lading { get; set; }
        public int OntluchtingsTijd { get; set; }
        public string OudZegel { get; set; }
        public string NieuwZegel { get; set; }
        public bool ContainerVentilatie { get; set; }
        public Herkomst Herkomst { get; set; }
        public string Memo { get; set; }
        public string MeetMateriaal { get; set; }
        public DateTime DateNow { get; set; }
        public bool Ontgassing { get; set; }
        public SoortMeting SoortMeting { get; set; }
        public LocatieMeting LocatieMeting { get; set; }
        public string ContainerKenteken { get; set; }
        public Supplier Supplier { get; set; }
        public Flow Flow { get; set; }
        public double Prijs { get; set; }
        public bool Luchtmonster { get; set; }

        public Meting() {
            Container = new Container(0, "");
            Werknemer = new Werknemer(0, "");
            Resultaat = new Resultaat(0, "");
            Advies = new Advies(0, "");
            Opdrachtgever = new Opdrachtgever(0, "");
            Locatie = new Locatie(0, "", null, 0);
            Lading = new Lading(0, "");
            Herkomst = new Herkomst(0, "");
            SoortMeting = new SoortMeting(0, "");
            LocatieMeting = new LocatieMeting(0, "");
            Supplier = new Supplier(0, "");
            Flow = new Flow(0, "");
        }
    }
}
