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
using Interfaces;
using DAL;
using Domain.Enums;

namespace Bodegro
{

    public partial class InlogPagina : Form
    {
        public object Inlogaccount;
        //private readonly DoctorDAL doctorDAL = new DoctorDAL();
       // private readonly AdminDAL adminDAL =  new AdminDAL();
        private readonly UserContainer userContainer; 

        public InlogPagina(IUser context)
        {
            InitializeComponent();
            userContainer = new UserContainer(context);
            EmailInputUser.Text = "timHaiwan";
        }
        public bool inlog = false;

        private void LogInButton_Click(object sender, EventArgs e)
        {
            string EmailInput = EmailInputUser.Text;
            string PasswordInput = PassWordInputUser.Text;
            Inlogaccount = userContainer.DoctorLogin(EmailInput, PasswordInput);

            if (HasValidID(Inlogaccount) == false)
            {
                Inlogaccount = userContainer.AdminLogin(EmailInput, PasswordInput);
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
                    if (Inlogaccount is Doctor doctortest)
                    {
                        Doctor doctor = (Doctor)Inlogaccount;
                        MainPage mainPage = new MainPage((Doctor)Inlogaccount);
                        mainPage.Show();
                    }
                    else if (Inlogaccount is Admin admintest)
                    {
                        Admin admin = (Admin)Inlogaccount;
                        MainPage mainPage = new MainPage((Admin)Inlogaccount);
                        mainPage.Show();
                    }



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
