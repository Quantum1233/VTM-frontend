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
    public partial class FrontEnd : Form
    {
        Manager manager;

        public FrontEnd(Manager manager)
        {
            InitializeComponent();
            this.manager = manager;
            lblLoggedInAs.Text = manager.LoggedIn.Voornaam + " " + manager.LoggedIn.Achternaam;
            SetUpGui();
            this.StartPosition = FormStartPosition.CenterScreen;
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
            cbOrderCompany.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbOrderCompany.AutoCompleteSource = AutoCompleteSource.CustomSource;
            foreach (Opdrachtgever o in manager.Opdrachtgevers)
            {
                cbOrderCompany.Items.Add(o.Naam);
                cbOrderCompany.AutoCompleteCustomSource.Add(o.Naam);
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
            cbOrigin.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbOrigin.AutoCompleteSource = AutoCompleteSource.CustomSource;
 
            foreach (Herkomst herkomst in manager.Herkomsten) {
                cbOrigin.Items.Add(herkomst.Naam);
                cbOrigin.AutoCompleteCustomSource.Add(herkomst.Naam);
            }

            // Ladingen
            cbCargo.Items.Clear();
            cbCargo.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbCargo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            foreach (Lading l in manager.Ladingen) {
                cbCargo.Items.Add(l.Naam);
                cbCargo.AutoCompleteCustomSource.Add(l.Naam);
            }

            // Suppliers
            cbSupplier.Items.Clear();
            cbSupplier.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbSupplier.AutoCompleteSource = AutoCompleteSource.CustomSource;
            foreach (Supplier s in manager.Suppliers) {
                cbSupplier.Items.Add(s.Naam);
                cbSupplier.AutoCompleteCustomSource.Add(s.Naam);
            }

            // Werknemers
            cbEmployee.Items.Clear();
            cbEmployee.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbEmployee.AutoCompleteSource = AutoCompleteSource.CustomSource;
            foreach (Werknemer w in manager.Werknemers) {
                cbEmployee.Items.Add(w.Naam);
                cbEmployee.AutoCompleteCustomSource.Add(w.Naam);
            }

            // Resultaten
            cbResult.Items.Clear();
            cbResult.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbResult.AutoCompleteSource = AutoCompleteSource.CustomSource;
            foreach (Resultaat r in manager.Resultaten) {
                cbResult.Items.Add(r.ResultaatNaam);
                cbResult.AutoCompleteCustomSource.Add(r.ResultaatNaam);
            }

            // Adviesen
            cbAdvice.Items.Clear();
            cbAdvice.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbAdvice.AutoCompleteSource = AutoCompleteSource.CustomSource;
            foreach (Advies a in manager.Adviesen) {
                cbAdvice.Items.Add(a.Omschrijving);
                cbAdvice.AutoCompleteCustomSource.Add(a.Omschrijving);
            }

            // Flows
            cbFlow.Items.Clear();
            cbFlow.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbFlow.AutoCompleteSource = AutoCompleteSource.CustomSource;
            foreach (Flow f in manager.Flows) {
                cbFlow.Items.Add(f.Omschrijving);
                cbFlow.AutoCompleteCustomSource.Add(f.Omschrijving);
            }

            // Locaties
            cbLocation.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbLocation.AutoCompleteSource = AutoCompleteSource.CustomSource;

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

        // Locatie en supplier combobox vullen op basis van geselecteerde opdrachtgever
        private void cbOrderCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbSupplier.Items.Clear();
            cbLocation.Items.Clear();
            cbSupplier.AutoCompleteCustomSource.Clear();
            cbLocation.AutoCompleteCustomSource.Clear();
            foreach (Opdrachtgever o in manager.Opdrachtgevers) {
                if (o.Naam == cbOrderCompany.SelectedItem.ToString())
                {
                    foreach (Supplier s in o.Suppliers)
                    {
                        cbSupplier.Items.Add(s.Naam);
                        cbSupplier.AutoCompleteCustomSource.Add(s.Naam);
                    }

                    foreach (Locatie l in o.Locaties) {
                        cbLocation.Items.Add(l.Naam);
                        cbLocation.AutoCompleteCustomSource.Add(l.Naam);
                    }
                }
            }
        }

        public void CheckTextbox(TextBox tb, CheckBox cbx) {
            if (tb.Text != "") {
                int number;
                if (!Int32.TryParse(tb.Text, out number)) {
                    MessageBox.Show("Vul een getal in!");
                    tb.Text = "";
                    tb.Focus();
                    cbx.Checked = false;
                }else {
                    cbx.Checked = true;
                }
            }else {
                cbx.Checked = false;
            }
        }

        //****************************************** Checks of gaswaarde is ingevuld ************************************************************************

        private void tbPid_TextChanged(object sender, EventArgs e) {
            CheckTextbox(tbPid, cbxPid);
        }

        private void tbOxygen_TextChanged(object sender, EventArgs e) {
            CheckTextbox(tbOxygen, cbxOxygen);
        }

        private void tbExplosion_TextChanged(object sender, EventArgs e) {
            CheckTextbox(tbExplosion, cbxExplosion);
        }

        private void tbCarbonMono_TextChanged(object sender, EventArgs e) {
            CheckTextbox(tbCarbonMono, cbxCarbonMono);
        }

        private void tbCarbonDio_TextChanged(object sender, EventArgs e) {
            CheckTextbox(tbCarbonDio, cbxCarbonDioxide);
        }

        private void tbPhosphine_TextChanged(object sender, EventArgs e) {
            CheckTextbox(tbPhosphine, cbxPhosphine);
        }

        private void tbAmmonia_TextChanged(object sender, EventArgs e) {
            CheckTextbox(tbAmmonia, cbxAmmonia);
        }

        private void tbMethylbromide_TextChanged(object sender, EventArgs e) {
            CheckTextbox(tbMethylbromide, cbxMethylbromide);
        }

        private void tbFormaldehyde_TextChanged(object sender, EventArgs e) {
            CheckTextbox(tbFormaldehyde, cbxFormaldehyde);
        }

        private void tbChloropicrine_TextChanged(object sender, EventArgs e) {
            CheckTextbox(tbChloropicrine, cbxChloropicrine);
        }

        private void tbBenzene_TextChanged(object sender, EventArgs e) {
            CheckTextbox(tbBenzene, cbxBenzene);
        }

        private void tbToluene_TextChanged(object sender, EventArgs e) {
            CheckTextbox(tbToluene, cbxToluene);
        }

        private void tbDiChloroEthane_TextChanged(object sender, EventArgs e) {
            CheckTextbox(tbDiChloroEthane, cbxDiChloroEthane);
        }

        private void tbSulfurylFluoride_TextChanged(object sender, EventArgs e) {
            CheckTextbox(tbSulfurylFluoride, cbxSulfurylfluoride);
        }

        private void tbDichloroMethane_TextChanged(object sender, EventArgs e) {
            CheckTextbox(tbDichloroMethane, cbxDichloromethane);
        }

        private void tbEthyleneOxide_TextChanged(object sender, EventArgs e) {
            CheckTextbox(tbEthyleneOxide, cbxEthyleneOxide);
        }

        private void tbCyclohexane_TextChanged(object sender, EventArgs e) {
            CheckTextbox(tbCyclohexane, cbxCyclohexane);
        }

        private void tbStyrene_TextChanged(object sender, EventArgs e) {
            CheckTextbox(tbStyrene, cbxStyrene);
        }

        private void tbXylene_TextChanged(object sender, EventArgs e) {
            CheckTextbox(tbXylene, cbxXylene);
        }

        private void tbAlphaPinene_TextChanged(object sender, EventArgs e) {
            CheckTextbox(tbAlphaPinene, cbxAlphaPinene);
        }

        private void tbIsoPentane_TextChanged(object sender, EventArgs e) {
            CheckTextbox(tbIsoPentane, cbxIsoPentane);
        }

        private void tbHydrogen_TextChanged(object sender, EventArgs e) {
            CheckTextbox(tbHydrogen, cbxHydrogen);
        }

    }
}
