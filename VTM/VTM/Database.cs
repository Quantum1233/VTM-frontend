﻿using System;
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
        private Manager manager;

        public Database(Manager manager)
        {
            // Set up database connection
            String pad;
            String provider;
            String connectionString;

            provider = "Provider=Microsoft.ACE.OLEDB.12.0";
            pad = @"Data Source=C:\Users\msi\Desktop\VT-M\VanTienenGasmeting_be.accdb"; // VanTienenGasmeting_be.accdb is the name of the database

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
            catch
            {
                MessageBox.Show("Database connection error", "Error");
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
            catch
            {
                MessageBox.Show("Error reading database", "Error");
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

        // Alle Suppliers binden aan de juiste opdrachtgevers
        public void BindOpdrachtgeverSupplier()
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
            }
            catch
            {
                MessageBox.Show("Error reading database", "Error");
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
