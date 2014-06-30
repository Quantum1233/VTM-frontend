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
        public Meting CurrentMeting { get; set; }

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
                if (a.Gebruikersnaam.ToLower() == Gebruikersnaam.ToLower() && a.Wachtwoord == Wachtwoord) {
                    LoggedIn = a;
                    return true;
                }
            }
            return false;
        }

        public void setField(string Field, string WaardeStrings, bool WaardeBool, double WaardeDouble, DateTime WaardeTijd, int WaardeInt) {
            switch (Field) {
                case "datum":
                    CurrentMeting.Datum = WaardeTijd;
                    break;
                case "tijd":
                    CurrentMeting.Tijd = WaardeTijd;
                    break;
                case "temperatuur":
                    CurrentMeting.Temperatuur = WaardeInt;
                    break;
                case "fyconummer":
                    CurrentMeting.Fyconummer = WaardeStrings;
                    break;
                case "ordernummer":
                    CurrentMeting.Ordernummer = WaardeStrings;
                    break;
                case "container":
                    
                    break;
                case "werknemer":
                    foreach (Werknemer w in werknemers) {
                        if (w.Naam == WaardeStrings) {
                            CurrentMeting.Werknemer = w;
                        }
                    }
                    break;
                case "resultaat":
                    foreach (Resultaat r in resultaten) {
                        if (r.ResultaatNaam == WaardeStrings) {
                            CurrentMeting.Resultaat = r;
                        }
                    }
                    break;
                case "advies":
                    foreach (Advies a in adviesen) {
                        if (a.Omschrijving == WaardeStrings) {
                            CurrentMeting.Advies = a;
                        }
                    }
                    break;
                case "opdrachtgever":
                    foreach(Opdrachtgever o in opdrachtgevers){
                        if(o.Naam == WaardeStrings){
                            CurrentMeting.Opdrachtgever = o;
                        }
                    }
                    break;
                case "locatie":
                    foreach (Locatie l in CurrentMeting.Opdrachtgever.Locaties) {
                        if (l.Naam == WaardeStrings) {
                            CurrentMeting.Locatie = l;
                        }
                    }
                    break;
                case "lading":
                    foreach(Lading l in ladingen){
                        if(l.Naam == WaardeStrings){
                            CurrentMeting.Lading = l;
                        }
                    }
                    break;
                case "ontluchting":
                    CurrentMeting.Ontluchting = WaardeInt;
                    break;
                case "oudzegel":
                    CurrentMeting.OudZegel = WaardeStrings;
                    break;
                case "nieuwzegel":
                    CurrentMeting.NieuwZegel = WaardeStrings;
                    break;
                case "containerventilatie":
                    CurrentMeting.ContainerVentilatie = WaardeBool;
                    break;
                case "herkomst":
                    foreach (Herkomst h in herkomsten) {
                        if (h.Naam == WaardeStrings) {
                            CurrentMeting.Herkomst = h;
                        }
                    }
                    break;
                case "memo":
                    CurrentMeting.Memo = WaardeStrings;
                    break;
                case "meetmateriaal":
                    CurrentMeting.MeetMateriaal = WaardeStrings;
                    break;
                case "datenow":
                    CurrentMeting.DateNow = WaardeTijd;
                    break;
                case "ontgassing":
                    CurrentMeting.Ontgassing = WaardeBool;
                    break;
                case "soortmeting":
                    foreach (SoortMeting s in soortMetingen) {
                        if (s.Naam == WaardeStrings) {
                            CurrentMeting.SoortMeting = s;
                        }
                    }
                    break;
                case "locatiemeting":
                    foreach (LocatieMeting l in locatieMetingen) {
                        if (l.Naam == WaardeStrings) {
                            CurrentMeting.LocatieMeting = l;
                        }
                    }
                    break;
                case "containerkenteken":
                    CurrentMeting.ContainerKenteken = WaardeStrings;
                    break;
                case "supplier":
                    foreach (Supplier s in suppliers) {
                        if (s.Naam == WaardeStrings) {
                            CurrentMeting.Supplier = s;
                        }
                    }
                    break;
                case "flow":
                    foreach(Flow f in flows){
                        if(f.Omschrijving == WaardeStrings) {
                            CurrentMeting.Flow =  f;
                        }
                    }
                    break;
                case "prijs":
                    CurrentMeting.Prijs = WaardeDouble;
                    break;
                case "luchtmonster":
                    CurrentMeting.Luchtmonster = WaardeBool;
                    break;
            }
        }
    }
}
