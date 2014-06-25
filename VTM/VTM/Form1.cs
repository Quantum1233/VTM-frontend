using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VTM
{
    public partial class Form1 : Form
    {
        Manager manager;

        public Form1()
        {
            InitializeComponent();
            manager = new Manager();
            SetUpGui();
        }

        private void SetUpGui()
        {
            // Meetmethodes
            lbxMMethod.Items.Add("Field Measurement");
            lbxMMethod.Items.Add("GDA2 Measurement");
            lbxMMethod.Items.Add("Gasmet");

            // Containernummer / Kenteken
            cbNumberType.Items.Add("ContainerNummer");
            cbNumberType.Items.Add("Kenteken");
            cbNumberType.SelectedIndex = 0;

            // Opdrachtgevers
            cbOrderCompany.Items.Clear();
            foreach (Opdrachtgever o in manager.Opdrachtgevers)
            {
                cbOrderCompany.Items.Add(o.Naam);
            }

            // Soort metingen
            cbMType.Items.Clear();
            foreach (SoortMeting s in manager.SoortMetingen) {
                cbMType.Items.Add(s.Naam);
            }
            cbMType.SelectedIndex = 0;

            // Locatie Metingen
            cbMLocation.Items.Clear();
            foreach (LocatieMeting locatie in manager.LocatieMetingen) {
                cbMLocation.Items.Add(locatie.Naam);
            }
            cbMLocation.SelectedIndex = 0;

            // Herkomsten
            cbOrigin.Items.Clear();
            foreach (Herkomst h in manager.Herkomsten) {
                cbOrigin.Items.Add(h.Naam);
            }

            // Ladingen
            cbCargo.Items.Clear();
            foreach (Lading l in manager.Ladingen) {
                cbCargo.Items.Add(l.Naam);
            }

            // Suppliers
            cbSupplier.Items.Clear();
            foreach (Supplier s in manager.Suppliers) {
                cbSupplier.Items.Add(s.Naam);
            }

            // Weeknr
            tbWeeknr.Text = Convert.ToString(getWeekNr(DateTime.Now));
        }

        // Weeknummer berekenen
        private int getWeekNr(DateTime date)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;

            return cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
        }

        // Filteren opdrachtgevers
        private void cbOrderCompany_DropDown(object sender, EventArgs e)
        {
            cbOrderCompany.Items.Clear();
            List<string> templist = new List<string>();
            foreach (Opdrachtgever o in manager.Opdrachtgevers)
            {
                if (o.Naam.ToLower().StartsWith(cbOrderCompany.Text.ToLower()))
                {
                    cbOrderCompany.Items.Add(o.Naam);
                }
            }
        }

        private void cbOrderCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbSupplier.Items.Clear();
            foreach (Opdrachtgever o in manager.Opdrachtgevers) {
                if (o.Naam == cbOrderCompany.SelectedItem.ToString())
                {
                    foreach (Supplier s in o.Suppliers)
                    {
                        cbSupplier.Items.Add(s.Naam);
                    }
                }
            }
        }

    }
}
