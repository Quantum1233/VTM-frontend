using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VTM
{
    class Database
    {
        private OleDbConnection connection;
        private List<string> opdrachtgevers;
        public List<string> Opdrachtgevers { get { return opdrachtgevers; } }

        public Database()
        {
            // Set up database connection
            String pad;
            String provider;
            String connectionString;

            provider = "Provider=Microsoft.ACE.OLEDB.12.0";
            pad = @"Data Source=C:\Users\msi\Desktop\VT-M\VanTienenGasmeting_be.accdb"; // VanTienenGasmeting_be.accdb is the name of the database

            connectionString = provider + ";" + pad;

            connection = new OleDbConnection(connectionString);

            // Write all database tables to corresponding lists
            opdrachtgevers = GetOpdrachtgevers();
        }

        public void RunDBQuery(string SQLQuery)
        {
            OleDbCommand command = new OleDbCommand(SQLQuery, connection);

            try
            {
                connection.Open(); // open the db connection
                command.ExecuteNonQuery(); // run the command
            }
            catch
            {
                MessageBox.Show("Database connection error", "Error");
            }
            finally
            {
                connection.Close(); // close the db connection     
            }
        } // Runs the supplied SQL query on the database

        private List<string> GetOpdrachtgevers()
        {
            String sql = "SELECT * FROM [Opdrachtgever]";
            OleDbCommand command = new OleDbCommand(sql, connection);
            List<string> tempList = new List<string>();

            try
            {
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    tempList.Add(Convert.ToString(reader["OpdrachtgeverID"]) + " " + Convert.ToString(reader["Naam"]));
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
    }
}
