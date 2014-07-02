using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTM
{
    public class Manager
    {
        private List<Opdrachtgever> opdrachtgevers;
        public List<Opdrachtgever> Opdrachtgevers { get { return opdrachtgevers; } }
        private List<SoortMeting> soortMetingen;
        public List<SoortMeting> SoortMetingen { get { return soortMetingen; } }
        private List<LocatieMeting> locatieMetingen;
        public List<LocatieMeting> LocatieMetingen { get { return locatieMetingen; } }
        private List<Herkomst> herkomsten;
        public List<Herkomst> Herkomsten { get { return herkomsten; } }
        private List<Lading> ladingen;
        public List<Lading> Ladingen { get { return ladingen; } }
        private List<Supplier> suppliers;
        public List<Supplier> Suppliers { get { return suppliers; } }
        private List<Regio> regios;
        public List<Regio> Regios { get { return regios; } }
        private List<Locatie> locaties;
        public List<Locatie> Locaties { get { return locaties; } }
        private List<Account> accounts;
        public List<Account> Accounts { get { return accounts; } }
        private List<Werknemer> werknemers;
        public List<Werknemer> Werknemers { get { return werknemers; } }
        private List<Resultaat> resultaten;
        public List<Resultaat> Resultaten { get { return resultaten; } }
        private List<Advies> adviesen;
        public List<Advies> Adviesen { get { return adviesen; } }
        private List<Flow> flows;
        public List<Flow> Flows { get { return flows; } }
        private Database database;
        public Account LoggedIn { get; set; }

        public Manager() {
            database = new Database(this);
            this.opdrachtgevers = database.GetAllOpdrachtgevers();
            this.soortMetingen = database.GetAllSoortMetingen();
            this.locatieMetingen = database.GetAllLocatieMeting();
            this.herkomsten = database.GetAllHerkomsten();
            this.ladingen = database.GetAllLadingen();
            this.suppliers = database.GetAllSuppliers();
            this.regios = database.GetAllRegios();
            this.locaties = database.GetAllLocaties();
            this.accounts = database.GetAllAccounts();
            this.werknemers = database.GetAllWerknemers();
            this.resultaten = database.GetAllResultaten();
            this.adviesen = database.GetAllAdviesen();
            this.flows = database.GetAllFlows();
            database.BindOpdrachtgeverData();
        }

        public bool LogIn(string Gebruikersnaam, string Wachtwoord) {
            foreach (Account a in accounts) {
                if (a.Gebruikersnaam == Gebruikersnaam && a.Wachtwoord == Wachtwoord) {
                    LoggedIn = a;
                    return true;
                }
            }
            return false;
        }

        public Meting GetMeting(int Id) {
            return database.GetMeting(Id);
        }
    }
}
