using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bodegro
{
    public partial class InlogPagina : Form
    {
        public InlogPagina()
        {
            InitializeComponent();
        }
        public bool inlog = false;

        private void LogInButton_Click(object sender, EventArgs e)
        {
            string EmailInput = EmailInputUser.Text;
            string PasswordInput = PassWordInputUser.Text;
            TwoFactorPage twoFactorPage = new TwoFactorPage();
            if (twoFactorPage.ShowDialog() == DialogResult.OK && twoFactorPage.Confirmation == true)
            {

            }
            this.Close();
        }
    }
}
