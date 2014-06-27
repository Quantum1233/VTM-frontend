using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTM {
    public class Account {
        public int Id { get; set; }
        public string Gebruikersnaam { get; set; }
        public string Wachtwoord { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }

        public Account(int Id, string Gebruikersnaam, string Wachtwoord, string Voornaam, string Achternaam) {
            this.Id = Id;
            this.Gebruikersnaam = Gebruikersnaam;
            this.Wachtwoord = Wachtwoord;
            this.Voornaam = Voornaam;
            this.Achternaam = Achternaam;
        }
    }
}
