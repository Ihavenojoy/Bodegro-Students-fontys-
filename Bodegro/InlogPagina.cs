using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain.Containers;
using Domain.Modules;
using BodegroInterfaces;
using DAL;

namespace Bodegro
{

    public partial class InlogPagina : Form
    {
        public object Inlogaccount;
        private readonly DoctorDAL doctorDAL = new DoctorDAL();
        private readonly AdminDAL adminDAL =  new AdminDAL();
        private readonly DoctorContainer doctorContainer;
        private readonly AdminContainer adminContainer;

        public InlogPagina()
        {
            InitializeComponent();
            doctorContainer = new DoctorContainer(doctorDAL);
            adminContainer = new AdminContainer(adminDAL);
        }
        public bool inlog = false;

        private void LogInButton_Click(object sender, EventArgs e)
        {
            string EmailInput = EmailInputUser.Text;
            string PasswordInput = PassWordInputUser.Text;
            Inlogaccount = doctorContainer.Login(EmailInput, PasswordInput);

            if (HasValidID(Inlogaccount) == false)
            {
                Inlogaccount = adminContainer.Login(EmailInput, PasswordInput);
            }
            if (HasValidID(Inlogaccount))
            {

                TwoFactorPage twoFactorPage = new TwoFactorPage();
                if (twoFactorPage.ShowDialog() == DialogResult.OK && twoFactorPage.Confirmation)
                {
                    
                }
                if (twoFactorPage.Confirmation)
                {
                    this.Close();
                }
            }
            

        }
        private bool HasValidID(object account)
        {
            if (account is Doctor doctor && doctor.ID > 0)
            {
                return true;
            }
            else if (account is Admin admin && admin.ID > 0)
            {
                return true;
            }
            return false;
        }
    }
}
