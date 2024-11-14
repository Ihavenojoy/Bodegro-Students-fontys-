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
using Domain.Enums;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing.Text;
using System.Text.RegularExpressions;
using DAL;
using Microsoft.Extensions.Configuration;
using Domain.Containers.UserFile;
namespace Bodegro
{
    public partial class CreateUser : Form
    {
        UserContainer UserContainer;
        User user;
        private readonly IConfiguration iConfiguration;
        public CreateUser(int selectedtab,User user)
        {
            InitializeComponent();
            UserDAL UserDAL = new UserDAL(iConfiguration);
            UserContainer = new UserContainer(UserDAL);
            LoadUsers();
            this.tabControl1.SelectTab(selectedtab);
            if (user is User User)
            {
                    tabControl1.TabPages.RemoveAt(0);
            }

        }
        private bool IsValidPassword(string password)
        {
            var passwordPattern = @"^(?=.*[A-Z])(?=.*\d)(?=.*[\W]).{10,}$";
            return Regex.IsMatch(password, passwordPattern);
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            if (rbUser.Checked)
            {
                CreateUserforms();
            }
        }
        private void CreateUserforms()
        {
            if (string.IsNullOrWhiteSpace(tbNameUser.Text) || string.IsNullOrWhiteSpace(tbEmailUser.Text) || string.IsNullOrWhiteSpace(tbPasswordUser.Text) || string.IsNullOrWhiteSpace(cbRegioUser.Text))
            {
                MessageBox.Show("Vul alle velden in");
            }
            else if (!IsValidPassword(tbPasswordUser.Text))
            {
                MessageBox.Show("Wachtwoord moet minimaal 10 letters bevatten, inclusief 1 hoofdletter en 1 speciaal teken.");
            }
            else
            {
                Regio regio = (Regio)Enum.Parse(typeof(Regio), cbRegioUser.Text);
                User User = new User(tbNameUser.Text, tbEmailUser.Text, Role.Unkown);
                UserContainer.CreateUser(User, tbPasswordUser.Text);
                MessageBox.Show("Arts toegevoegd");
                lbUsers.Items.Add(User);
                lbUsers.Items.Clear();
                LoadUsers();
            }
        }
        private void LoadUsers()
        {
            lbUsers.Items.Clear();
            var Users = UserContainer.GetAllUsers();
            foreach (var User in Users)
            {
                lbUsers.Items.Add(User);
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (lbUsers.SelectedItem == null)
            {
                MessageBox.Show("Selecteer een arts om te verwijderen");
            }
            else
            {
                User User = (User)lbUsers.SelectedItem;
                UserContainer.DeleteUser(User.ID);
                MessageBox.Show("Product deleted");
                lbUsers.Items.Clear();
                LoadUsers();
            }
        }
    }
}
