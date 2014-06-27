using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTM
{
    class Manager
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
        private Database database;

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
            database.BindOpdrachtgeverData();
        }
    }
}
