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
        public int Ontluchting { get; set; }
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

        public Meting(int MetingId, DateTime Datum, DateTime Tijd, int Temperatuur, string Fyconummer, string Ordernummer, Container container,
            Werknemer Werknemer, Resultaat Resultaat, Advies Advies, Opdrachtgever Opdrachtgever, Locatie Locatie, Lading Lading, int Ontluchting,
            string OudZegel, string NieuwZegel, bool ContainerVentilatie, Herkomst Herkomst, string Memo, string MeetMateriaal, DateTime DateNow,
            bool Ontgassing, SoortMeting SoortMeting, LocatieMeting LocatieMeting, string ContainerKenteken, Supplier Supplier, Flow Flow, double Prijs, bool Luchtmonster) {

        }
        }
}
