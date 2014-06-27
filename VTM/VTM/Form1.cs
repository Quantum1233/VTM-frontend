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

        // Locatie en supplier combobox vullen op basis van geselecteerde opdrachtgever
        private void cbOrderCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbSupplier.Items.Clear();
            cbLocation.Items.Clear();
            foreach (Opdrachtgever o in manager.Opdrachtgevers) {
                if (o.Naam == cbOrderCompany.SelectedItem.ToString())
                {
                    foreach (Supplier s in o.Suppliers)
                    {
                        cbSupplier.Items.Add(s.Naam);
                    }

                    foreach (Locatie l in o.Locaties) {
                        cbLocation.Items.Add(l.Naam);
                    }
                }
            }
        }

        private void tbPid_TextChanged(object sender, EventArgs e) {
            if (tbPid.Text != "") {
                cbxPid.Checked = true;
            }
            else{
                cbxPid.Checked = false;
            }
        }

        private void tbOxygen_TextChanged(object sender, EventArgs e) {
            if (tbOxygen.Text != "") {
                cbxOxygen.Checked = true;
            }
            else {
                cbxOxygen.Checked = false;
            }
        }

        private void tbExplosion_TextChanged(object sender, EventArgs e) {
            if (tbExplosion.Text != "") {
                cbxExplosion.Checked = true;
            }
            else {
                cbxExplosion.Checked = false;
            }
        }

        private void tbCarbonMono_TextChanged(object sender, EventArgs e) {
            if (tbCarbonMono.Text != "") {
                cbxCarbonMono.Checked = true;
            }
            else {
                cbxCarbonMono.Checked = false;
            }
        }

        private void tbCarbonDio_TextChanged(object sender, EventArgs e) {
            if (tbCarbonDio.Text != "") {
                cbxCarbonDioxide.Checked = true;
            }
            else {
                cbxCarbonDioxide.Checked = false;
            }
        }

        private void tbPhosphine_TextChanged(object sender, EventArgs e) {
            if (tbPhosphine.Text != "") {
                cbxPhosphine.Checked = true;
            }
            else {
                cbxPhosphine.Checked = false;
            }
        }

        private void tbAmmonia_TextChanged(object sender, EventArgs e) {
            if (tbAmmonia.Text != "") {
                cbxAmmonia.Checked = true;
            }
            else {
                cbxAmmonia.Checked = false;
            }
        }

        private void tbMethylbromide_TextChanged(object sender, EventArgs e) {
            if (tbMethylbromide.Text != "") {
                cbxMethylbromide.Checked = true;
            }
            else {
                cbxMethylbromide.Checked = false;
            }
        }

        private void tbFormaldehyde_TextChanged(object sender, EventArgs e) {
            if (tbFormaldehyde.Text != "") {
                cbxFormaldehyde.Checked = true;
            }
            else {
                cbxFormaldehyde.Checked = false;
            }
        }

        private void tbChloropicrine_TextChanged(object sender, EventArgs e) {
            if (tbChloropicrine.Text != "") {
                cbxChloropicrine.Checked = true;
            }
            else {
                cbxChloropicrine.Checked = false;
            }
        }

        private void tbBenzene_TextChanged(object sender, EventArgs e) {
            if (tbBenzene.Text != "") {
                cbxBenzene.Checked = true;
            }
            else {
                cbxBenzene.Checked = false;
            }
        }

        private void tbToluene_TextChanged(object sender, EventArgs e) {
            if (tbToluene.Text != "") {
                cbxToluene.Checked = true;
            }
            else {
                cbxToluene.Checked = false;
            }
        }

        private void tbDiChloroEthane_TextChanged(object sender, EventArgs e) {
            if (tbDiChloroEthane.Text != "") {
                cbxDiChloroEthane.Checked = true;
            }
            else {
                cbxDiChloroEthane.Checked = false;
            }
        }

        private void tbSulfurylFluoride_TextChanged(object sender, EventArgs e) {
            if (tbSulfurylFluoride.Text != "") {
                cbxSulfurylfluoride.Checked = true;
            }
            else {
                cbxSulfurylfluoride.Checked = false;
            }
        }

        private void tbDichloroMethane_TextChanged(object sender, EventArgs e) {
            if (tbDichloroMethane.Text != "") {
                cbxDichloromethane.Checked = true;
            }
            else {
                cbxDichloromethane.Checked = false;
            }
        }

        private void tbEthyleneOxide_TextChanged(object sender, EventArgs e) {
            if (tbEthyleneOxide.Text != "") {
               cbxEthyleneOxide.Checked = true;
            }
            else {
                cbxEthyleneOxide.Checked = false;
            }
        }

        private void tbCyclohexane_TextChanged(object sender, EventArgs e) {
            if (tbCyclohexane.Text != "") {
                cbxCyclohexane.Checked = true;
            }
            else {
                cbxCyclohexane.Checked = false;
            }
        }

        private void tbStyrene_TextChanged(object sender, EventArgs e) {
            if (tbStyrene.Text != "") {
                cbxStyrene.Checked = true;
            }
            else {
                cbxStyrene.Checked = false;
            }
        }

        private void tbXylene_TextChanged(object sender, EventArgs e) {
            if (tbXylene.Text != "") {
                cbxXylene.Checked = true;
            }
            else {
                cbxXylene.Checked = false;
            }
        }

        private void tbAlphaPinene_TextChanged(object sender, EventArgs e) {
            if (tbAlphaPinene.Text != "") {
                cbxAlphaPinene.Checked = true;
            }
            else {
                cbxAlphaPinene.Checked = false;
            }
        }

        private void tbIsoPentane_TextChanged(object sender, EventArgs e) {
            if (tbIsoPentane.Text != "") {
                cbxIsoPentane.Checked = true;
            }
            else {
                cbxIsoPentane.Checked = false;
            }
        }

        private void tbHydrogen_TextChanged(object sender, EventArgs e) {
            if (tbHydrogen.Text != "") {
               cbxHydrogen.Checked = true;
            }
            else {
                cbxHydrogen.Checked = false;
            }
        }
    }
}
