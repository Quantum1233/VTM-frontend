using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VTM
{
    class Database
    {
        private OleDbConnection connection;
        private Manager manager;
        int ContainerID = 0;
        int WerknemerID = 0;
        int ResultaatID = 0;
        int AdviesID = 0;
        int OpdrachtgeverID = 0;
        int LocatieID = 0;
        int LadingID = 0;
        int HerkomstID = 0;
        int SoortmetingID = 0;
        int LocatieMetingID = 0;
        int SupplierID = 0;
        int FlowID = 0;
        Meting tempMeting;

        public Database(Manager manager)
        {
            // Set up database connection
            String pad;
            String provider;
            String connectionString;
            tempMeting = new Meting();

            provider = "Provider=Microsoft.ACE.OLEDB.12.0";
            pad = @"Data Source=C:\VanTienenGasmeting_be.accdb"; // VanTienenGasmeting_be.accdb is the name of the database

            connectionString = provider + ";" + pad;

            connection = new OleDbConnection(connectionString);
            this.manager = manager;
        }

        public void RunDBQuery(string SQLQuery)
        {
            OleDbCommand command = new OleDbCommand(SQLQuery, connection);

            try
            {
                connection.Open(); // open the db connection
                command.ExecuteNonQuery(); // run the command
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);//"Database connection error", "Error");
            }
            finally
            {
                connection.Close(); // close the db connection     
            }
        } // Runs the supplied SQL query on the database

        // Alle opdrachtgevers uit database halen
        public List<Opdrachtgever> GetAllOpdrachtgevers()
        {
            String sql = "SELECT * FROM [Opdrachtgever]";
            OleDbCommand command = new OleDbCommand(sql, connection);
            List<Opdrachtgever> tempList = new List<Opdrachtgever>();

            try
            {
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    tempList.Add(new Opdrachtgever(Convert.ToInt32(reader["OpdrachtgeverID"]), Convert.ToString(reader["Naam"])));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);//"Database connection error", "Error");
            }
            finally
            {
                connection.Close();
            }

            tempList.Sort(delegate(Opdrachtgever p1, Opdrachtgever p2)
                {
                    return p1.Naam.CompareTo(p2.Naam);
                }
            );

            return tempList;
        }

        // Alle SoortMetingen uit database halen
        public List<SoortMeting> GetAllSoortMetingen()
        {
            String sql = "SELECT * FROM [SoortMeting]";
            OleDbCommand command = new OleDbCommand(sql, connection);
            List<SoortMeting> tempList = new List<SoortMeting>();

            try
            {
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    tempList.Add(new SoortMeting(Convert.ToInt32(reader["SoortMetingId"]), Convert.ToString(reader["SoortMeting"])));
                }
            }
            catch
            {
                MessageBox.Show("Error reading database", "Error");
            }
            finally
            {
                connection.Close();
            }
            return tempList;
        }

        // Alle LocatieMetingen uit database halen
        public List<LocatieMeting> GetAllLocatieMeting()
        {
            String sql = "SELECT * FROM [LocatieMeting]";
            OleDbCommand command = new OleDbCommand(sql, connection);
            List<LocatieMeting> tempList = new List<LocatieMeting>();

            try
            {
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    tempList.Add(new LocatieMeting(Convert.ToInt32(reader["LocatieMetingId"]), Convert.ToString(reader["LocatieMetingNaam"])));
                }
            }
            catch
            {
                MessageBox.Show("Error reading database", "Error");
            }
            finally
            {
                connection.Close();
            }
            return tempList;
        }

        // Alle Herkomsten uit database halen
        public List<Herkomst> GetAllHerkomsten()
        {
            String sql = "SELECT * FROM [Herkomst]";
            OleDbCommand command = new OleDbCommand(sql, connection);
            List<Herkomst> tempList = new List<Herkomst>();

            try
            {
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    tempList.Add(new Herkomst(Convert.ToInt32(reader["HerkomstId"]), Convert.ToString(reader["Herkomst"])));
                }
            }
            catch
            {
                MessageBox.Show("Error reading database", "Error");
            }
            finally
            {
                connection.Close();
            }

            tempList.Sort(delegate(Herkomst p1, Herkomst p2)
            {
                return p1.Naam.CompareTo(p2.Naam);
            });

            return tempList;
        }

        // Alle Ladingen uit database halen
        public List<Lading> GetAllLadingen()
        {
            String sql = "SELECT * FROM [Lading]";
            OleDbCommand command = new OleDbCommand(sql, connection);
            List<Lading> tempList = new List<Lading>();

            try
            {
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    tempList.Add(new Lading(Convert.ToInt32(reader["LadingId"]), Convert.ToString(reader["Naam"])));
                }
            }
            catch
            {
                MessageBox.Show("Error reading database", "Error");
            }
            finally
            {
                connection.Close();
            }

            tempList.Sort(delegate(Lading p1, Lading p2)
            {
                return p1.Naam.CompareTo(p2.Naam);
            });

            return tempList;
        }

        // Alle Suppliers uit database halen
        public List<Supplier> GetAllSuppliers()
        {
            String sql = "SELECT * FROM [Supplier]";
            OleDbCommand command = new OleDbCommand(sql, connection);
            List<Supplier> tempList = new List<Supplier>();

            try
            {
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    tempList.Add(new Supplier(Convert.ToInt32(reader["SupplierId"]), Convert.ToString(reader["Supplier"])));
                }
            }
            catch
            {
                MessageBox.Show("Error reading database", "Error");
            }
            finally
            {
                connection.Close();
            }

            tempList.Sort(delegate(Supplier p1, Supplier p2)
            {
                return p1.Naam.CompareTo(p2.Naam);
            });

            return tempList;
        }

        // Alle Regio's uit database halen
        public List<Regio> GetAllRegios() {
            String sql = "SELECT * FROM [Regio]";
            OleDbCommand command = new OleDbCommand(sql, connection);
            List<Regio> tempList = new List<Regio>();

            try {
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read()) {
                    tempList.Add(new Regio(Convert.ToInt32(reader["RegioId"]), Convert.ToString(reader["Regio"])));
                }
            }
            catch {
                MessageBox.Show("Error reading database at Regio", "Error");
            }
            finally {
                connection.Close();
            }

            tempList.Sort(delegate(Regio p1, Regio p2) {
                return p1.Naam.CompareTo(p2.Naam);
            });

            return tempList;
        }

        // Alle Locaties uit database halen
        public List<Locatie> GetAllLocaties() {
            String sql = "SELECT * FROM [Locatie]";
            OleDbCommand command = new OleDbCommand(sql, connection);
            List<Locatie> tempList = new List<Locatie>();

            try {
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                Regio regio = null;

                while (reader.Read()) {
                    int locatieId = Convert.ToInt32(reader["LocatieID"]);
                    string locatieNaam = Convert.ToString(reader["Naam"]);
                    int regioId = 0;
                    int opdrachtgeverId = Convert.ToInt32(reader["OpdrachtgeverID"]);
                    if (reader["RegioID"] != System.DBNull.Value) {
                        regioId = Convert.ToInt32(reader["RegioID"]);
                    }

                    foreach(Regio r in manager.Regios){
                        if (r.Id == regioId) {
                            regio = r;
                        }
                    }
                    tempList.Add(new Locatie(locatieId, locatieNaam, regio, opdrachtgeverId));
                }
            }
            catch {
                MessageBox.Show("Error reading database at Locatie at Location", "Error");
            }
            finally {
                connection.Close();
            }

            tempList.Sort(delegate(Locatie p1, Locatie p2) {
                return p1.Naam.CompareTo(p2.Naam);
            });

            return tempList;
        }

        // Alle InlogAccounts uit database halen
        public List<Account> GetAllAccounts() {
            String sql = "SELECT * FROM [WerknemerFrontEnd]";
            OleDbCommand command = new OleDbCommand(sql, connection);
            List<Account> tempList = new List<Account>();

            try {
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read()) {
                    tempList.Add(new Account(Convert.ToInt32(reader["Id"]), Convert.ToString(reader["Gebruikersnaam"]), Convert.ToString(reader["Wachtwoord"]), Convert.ToString(reader["Voornaam"]), Convert.ToString(reader["Achternaam"])));
                }
            }
            catch {
                MessageBox.Show("Error reading database at Account", "Error");
            }
            finally {
                connection.Close();
            }
            return tempList;
        }

        // Alle Werknemers uit database halen
        public List<Werknemer> GetAllWerknemers() {
            String sql = "SELECT * FROM [Werknemer]";
            OleDbCommand command = new OleDbCommand(sql, connection);
            List<Werknemer> tempList = new List<Werknemer>();

            try {
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read()) {
                    tempList.Add(new Werknemer(Convert.ToInt32(reader["WerknemerID"]), Convert.ToString(reader["Naam"])));
                }
            }
            catch {
                MessageBox.Show("Error reading database at Employee", "Error");
            }
            finally {
                connection.Close();
            }

            tempList.Sort(delegate(Werknemer p1, Werknemer p2) {
                return p1.Naam.CompareTo(p2.Naam);
            });

            return tempList;
        }

        // Alle Resultaten uit database halen
        public List<Resultaat> GetAllResultaten() {
            String sql = "SELECT * FROM [Resultaat]";
            OleDbCommand command = new OleDbCommand(sql, connection);
            List<Resultaat> tempList = new List<Resultaat>();

            try {
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read()) {
                    tempList.Add(new Resultaat(Convert.ToInt32(reader["ResultaatID"]), Convert.ToString(reader["Resultaat"])));
                }
            }
            catch {
                MessageBox.Show("Error reading database at Result", "Error");
            }
            finally {
                connection.Close();
            }
            return tempList;
        }

        // Alle adviesen uit de database halen
        public List<Advies> GetAllAdviesen() {
            String sql = "SELECT * FROM [Advies]";
            OleDbCommand command = new OleDbCommand(sql, connection);
            List<Advies> tempList = new List<Advies>();

            try {
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read()) {
                    tempList.Add(new Advies(Convert.ToInt32(reader["AdviesID"]), Convert.ToString(reader["Advies"])));
                }
            }
            catch {
                MessageBox.Show("Error reading database at Advies", "Error");
            }
            finally {
                connection.Close();
            }

            tempList.Sort(delegate(Advies p1, Advies p2) {
                return p1.Omschrijving.CompareTo(p2.Omschrijving);
            });

            return tempList;
        }

        // Alle Flows uit database halen
        public List<Flow> GetAllFlows() {
            String sql = "SELECT * FROM [Flow]";
            OleDbCommand command = new OleDbCommand(sql, connection);
            List<Flow> tempList = new List<Flow>();

            try {
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read()) {
                    tempList.Add(new Flow(Convert.ToInt32(reader["FlowID"]), Convert.ToString(reader["Flow"])));
                }
            }
            catch {
                MessageBox.Show("Error reading database at Flow", "Error");
            }
            finally {
                connection.Close();
            }

            tempList.Sort(delegate(Flow p1, Flow p2) {
                return p1.Omschrijving.CompareTo(p2.Omschrijving);
            });

            return tempList;
        }

        // gegevens binden aan opdrachtgevers (Supplier, Locatie)
        public void BindOpdrachtgeverData()
        {
            String sql = "SELECT * FROM [OpdrachtgeverSupplier]";
            OleDbCommand command = new OleDbCommand(sql, connection);

            try
            {
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    foreach (Opdrachtgever o in manager.Opdrachtgevers) {
                        if (o.Id == Convert.ToInt32(reader["OpdrachtgeverId"])) {
                            foreach (Supplier s in manager.Suppliers)
                            {
                                if (s.Id == Convert.ToInt32(reader["SupplierId"])) {
                                    o.Suppliers.Add(s);
                                }
                            }
                        }
                    }
                }

                foreach (Opdrachtgever o in manager.Opdrachtgevers) {
                    foreach (Locatie l in manager.Locaties) {
                        if (l.OpdrachtgeverId == o.Id) {
                            o.Locaties.Add(l);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error reading database at OpdrachtgeverSupplier", "Error");
            }
            finally
            {
                connection.Close();
            }
        }

        // Meting uit Database halen
        public Meting GetMeting(int Id) {
            Meting tempMeting = new Meting();
            String sql;
            if (Id == 0) {
                sql = "SELECT top 1 * FROM Meting order by MetingID desc";
            }
            else{
                sql = "SELECT * FROM Meting where MetingID = " + Id;
            }

                OleDbCommand command = new OleDbCommand(sql, connection);

                try {
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read()) {
                        tempMeting.MetingId = Convert.ToInt32(reader["MetingID"]);
                        if (reader["ContainerID"] != System.DBNull.Value) {
                            ContainerID = Convert.ToInt32(reader["ContainerID"]);
                        }
                        if (reader["WerknemerID"] != System.DBNull.Value) {
                            WerknemerID = Convert.ToInt32(reader["WerknemerID"]);
                        }
                        if (reader["ResultaatID"] != System.DBNull.Value) {
                            ResultaatID = Convert.ToInt32(reader["ResultaatID"]);
                        }
                        if (reader["AdviesID"] != System.DBNull.Value) {
                            AdviesID = Convert.ToInt32(reader["AdviesID"]);
                        }
                        if (reader["OpdrachtgeverID"] != System.DBNull.Value) {
                            OpdrachtgeverID = Convert.ToInt32(reader["OpdrachtgeverID"]);
                        }
                        if (reader["LocatieID"] != System.DBNull.Value) {
                            LocatieID = Convert.ToInt32(reader["LocatieID"]);
                        }
                        if (reader["LadingID"] != System.DBNull.Value) {
                            LadingID = Convert.ToInt32(reader["LadingID"]);
                        }
                        if (reader["HerkomstID"] != System.DBNull.Value) {
                            HerkomstID = Convert.ToInt32(reader["HerkomstID"]);
                        }
                        if (reader["SoortMetingID"] != System.DBNull.Value) {
                            SoortmetingID = Convert.ToInt32(reader["SoortMetingID"]);
                        }
                        if (reader["LocatieMetingID"] != System.DBNull.Value) {
                            LocatieMetingID = Convert.ToInt32(reader["LocatieMetingID"]);
                        }
                        if (reader["SupplierID"] != System.DBNull.Value) {
                            SupplierID = Convert.ToInt32(reader["SupplierID"]);
                        }
                        if (reader["FlowID"] != System.DBNull.Value) {
                            FlowID = Convert.ToInt32(reader["FlowID"]);
                        }

                        //Thread t1 = new Thread(findValues);
                        //t1.Start();
                        //while (!t1.IsAlive) ;
                        if (reader["Datum"] != System.DBNull.Value) {
                            tempMeting.Datum = Convert.ToDateTime(reader["Datum"]);
                        }
                        if (reader["Tijd"] != System.DBNull.Value) {
                            tempMeting.Tijd = Convert.ToDateTime(reader["Tijd"]); ;
                        }
                        if (reader["Temperatuur"] != System.DBNull.Value) {
                            tempMeting.Temperatuur = Convert.ToInt32(reader["Temperatuur"]);
                        }
                        if (reader["Fyconummer"] != System.DBNull.Value) {
                            tempMeting.Fyconummer = Convert.ToString(reader["Fyconummer"]);
                        }
                        if (reader["Ordernummer"] != System.DBNull.Value) {
                            tempMeting.Ordernummer = Convert.ToString(reader["Ordernummer"]);
                        }
                        if (reader["Ontluchtingstijd"] != System.DBNull.Value) {
                            tempMeting.OntluchtingsTijd = Convert.ToInt32(reader["Ontluchtingstijd"]);
                        }
                        if (reader["Oud Zegel"] != System.DBNull.Value) {
                            tempMeting.OudZegel = Convert.ToString(reader["Oud Zegel"]);
                        }
                        if (reader["Nieuw Zegel"] != System.DBNull.Value) {
                            tempMeting.NieuwZegel = Convert.ToString(reader["Nieuw Zegel"]);
                        }
                        if (reader["ContainerVentilatie"] != System.DBNull.Value) {
                            tempMeting.ContainerVentilatie = Convert.ToBoolean(reader["ContainerVentilatie"]);
                        }
                        if (reader["Memo"] != System.DBNull.Value) {
                            tempMeting.Memo = Convert.ToString(reader["Memo"]);
                        }
                        if (reader["Buisjes/gda"] != System.DBNull.Value) {
                            tempMeting.MeetMateriaal = Convert.ToString(reader["Buisjes/gda"]);
                        }
                        if (reader["DatumNow"] != System.DBNull.Value) {
                            tempMeting.DateNow = Convert.ToDateTime(reader["DatumNow"]);
                        }
                        if (reader["Ontgassing"] != System.DBNull.Value) {
                            tempMeting.Ontgassing = Convert.ToBoolean(reader["Ontgassing"]);
                        }
                        if (reader["Ontgassing"] != System.DBNull.Value) {
                            tempMeting.ContainerKenteken = Convert.ToString(reader["ContainerKenteken"]);
                        }
                        if (reader["ContainerKenteken"] != System.DBNull.Value) {
                            tempMeting.ContainerKenteken = Convert.ToString(reader["ContainerKenteken"]);
                        }
                        if (reader["Prijs"] != System.DBNull.Value) {
                            tempMeting.Prijs = Convert.ToDouble(reader["Prijs"]);
                        }
                        if (reader["Luchtmonster"] != System.DBNull.Value) {
                            tempMeting.Luchtmonster = Convert.ToBoolean(reader["Luchtmonster"]);
                        }
                    }
                }
                catch {
                    MessageBox.Show("Error reading database at Meting", "Error");
                }
                finally {
                    connection.Close();
                }

                // CONTAINER
                sql = "SELECT * FROM [Container] where [ContainerID] = " + ContainerID;
                command = new OleDbCommand(sql, connection);

                try {
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    while (reader.Read()) {
                        tempMeting.Container = new Container(ContainerID, Convert.ToString(reader["Containernummer"]));
                    }
                }
                catch {
                    MessageBox.Show("Error reading database at OpdrachtgeverSupplier", "Error");
                }
                finally {
                    connection.Close();
                }

                // Werknemer
                foreach (Werknemer w in manager.Werknemers) {
                    if (w.Id == WerknemerID) {
                        tempMeting.Werknemer = w;
                    }
                }

                // Resultaat
                foreach (Resultaat r in manager.Resultaten) {
                    if (r.Id == ResultaatID) {
                        tempMeting.Resultaat = r;
                    }
                }

                // Advies
                foreach (Advies a in manager.Adviesen) {
                    if (a.Id == AdviesID) {
                        tempMeting.Advies = a;
                    }
                }

                // Opdrachtgever
                foreach (Opdrachtgever o in manager.Opdrachtgevers) {
                    if (o.Id == OpdrachtgeverID) {
                        tempMeting.Opdrachtgever = o;
                    }
                }

                // Locatie
                foreach (Locatie l in manager.Locaties) {
                    if (l.Id == LocatieID) {
                        tempMeting.Locatie = l;
                    }
                }

                // Lading
                foreach (Lading l in manager.Ladingen) {
                    if (l.Id == LadingID) {
                        tempMeting.Lading = l;
                    }
                }

                // Herkomst
                foreach (Herkomst h in manager.Herkomsten) {
                    if (h.Id == HerkomstID) {
                        tempMeting.Herkomst = h;
                    }
                }

                // SoortMeting
                foreach (SoortMeting s in manager.SoortMetingen) {
                    if (s.Id == SoortmetingID) {
                        tempMeting.SoortMeting = s;
                    }
                }

                // LocatieMeting
                foreach (LocatieMeting l in manager.LocatieMetingen) {
                    if (l.Id == LocatieMetingID) {
                        tempMeting.LocatieMeting = l;
                    }
                }

                // Supplier
                foreach (Supplier s in manager.Suppliers) {
                    if (s.Id == SupplierID) {
                        tempMeting.Supplier = s;
                    }
                }

                // Flow
                foreach (Flow f in manager.Flows) {
                    if (f.FlowID == FlowID) {
                        tempMeting.Flow = f;
                    }
                }
            return tempMeting;
        }

        public void findValues() {
            // Werknemer
            foreach (Werknemer w in manager.Werknemers) {
                if (w.Id == WerknemerID) {
                    tempMeting.Werknemer = w;
                }
            }

            // Resultaat
            foreach (Resultaat r in manager.Resultaten) {
                if (r.Id == ResultaatID) {
                    tempMeting.Resultaat = r;
                }
            }

            // Advies
            foreach (Advies a in manager.Adviesen) {
                if (a.Id == AdviesID) {
                    tempMeting.Advies = a;
                }
            }

            // Opdrachtgever
            foreach (Opdrachtgever o in manager.Opdrachtgevers) {
                if (o.Id == OpdrachtgeverID) {
                    tempMeting.Opdrachtgever = o;
                }
            }

            // Locatie
            foreach (Locatie l in manager.Locaties) {
                if (l.Id == LocatieID) {
                    tempMeting.Locatie = l;
                }
            }

            // Lading
            foreach (Lading l in manager.Ladingen) {
                if (l.Id == LadingID) {
                    tempMeting.Lading = l;
                }
            }

            // Herkomst
            foreach (Herkomst h in manager.Herkomsten) {
                if (h.Id == HerkomstID) {
                    tempMeting.Herkomst = h;
                }
            }

            // SoortMeting
            foreach (SoortMeting s in manager.SoortMetingen) {
                if (s.Id == SoortmetingID) {
                    tempMeting.SoortMeting = s;
                }
            }

            // LocatieMeting
            foreach (LocatieMeting l in manager.LocatieMetingen) {
                if (l.Id == LocatieMetingID) {
                    tempMeting.LocatieMeting = l;
                }
            }

            // Supplier
            foreach (Supplier s in manager.Suppliers){
                if(s.Id == SupplierID){
                    tempMeting.Supplier = s;
                }
            }

            // Flow
            foreach (Flow f in manager.Flows) {
                if (f.FlowID == FlowID) {
                    tempMeting.Flow = f;
                }
            }
        }
    }
}
