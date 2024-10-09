using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BodegroInterfaces;
using DAL;

namespace Bodegro
{

    public partial class InlogPagina : Form
    {
        public object Inlogaccount;
        private readonly IDoctor _Doctoracces = new DoctorDAL();
        private readonly IAdmin _Adminacces =  new AdminDAL();

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
            _Doctoracces.DoctorLogin(EmailInput,PasswordInput);
            if (twoFactorPage.ShowDialog() == DialogResult.OK && twoFactorPage.Confirmation == true)
            {

            }
            this.Close();
        }
    }
}
