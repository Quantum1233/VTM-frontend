using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VTM {
    public partial class Login : Form {

        Manager manager;

        public Login() {
            InitializeComponent();
            manager = new Manager();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnLogin_Click(object sender, EventArgs e) {
            TryLogin();
        }

        private void TryLogin() {
            if (tbUsername.Text != "") {
                if (tbPassword.Text != "") {
                    if (manager.LogIn(tbUsername.Text, tbPassword.Text)) {
                        FrontEnd frontend = new FrontEnd(manager);
                        frontend.Show();
                        this.Hide();
                    }
                    else {
                        MessageBox.Show("Login Failed, Gebruikersnaam en/of wachtwoord onjuist");
                    }
                }
                else {
                    MessageBox.Show("Vul een wachtwoord in!");
                }
            }
            else {
                MessageBox.Show("Vul een gebruikersnaam in!");
            }
        }

        private void Login_KeyPress(object sender, KeyPressEventArgs e) {
            if (Convert.ToInt32(e.KeyChar) == 13) {
                TryLogin();
            }
        }

        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e) {
            if (Convert.ToInt32(e.KeyChar) == 13) {
                TryLogin();
            }
        }

        private void tbUsername_KeyPress(object sender, KeyPressEventArgs e) {
            if (Convert.ToInt32(e.KeyChar) == 13) {
                TryLogin();
            }
        }
    }
}
