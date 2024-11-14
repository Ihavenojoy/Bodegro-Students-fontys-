using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain.Modules;
using Interfaces;
using DAL;
using Domain.Enums;
using Domain.Containers.UserFile;

namespace Bodegro
{

    public partial class InlogPagina : Form
    {
        public object Inlogaccount;
        //private readonly UserDAL UserDAL = new UserDAL();
       // private readonly UserDAL UserDAL =  new UserDAL();
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
            Inlogaccount = userContainer.UserLogin(EmailInput, PasswordInput);

            if (HasValidID(Inlogaccount) == false)
            {
                Inlogaccount = userContainer.UserLogin(EmailInput, PasswordInput);
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
                    if (Inlogaccount is User Usertest)
                    {
                        User User = (User)Inlogaccount;
                        MainPage mainPage = new MainPage((User)Inlogaccount);
                        mainPage.Show();
                    }
                }
            }
            

        }
        private bool HasValidID(object account)
        {
            if (account is User User && User.ID > 0)
            {
                return true;
            }
            return false;
        }
    }
}
