using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.Containers;
using BLL.Modules;
using BLL.Enums;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing.Text;
using System.Text.RegularExpressions;
namespace Bodegro
{
    public partial class CreateUser : Form
    {
        DoctorContainer doctorContainer = new DoctorContainer();
        public CreateUser()
        {
            InitializeComponent();
            LoadDoctors();
        }
        private bool IsValidPassword(string password)
        {
            var passwordPattern = @"^(?=.*[A-Z])(?=.*\d)(?=.*[\W]).{10,}$";
            return Regex.IsMatch(password, passwordPattern);
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            if (rbDoctor.Checked)
            {
                CreateDoctor();
            }
        }
        private void CreateDoctor()
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
                Doctor doctor = new Doctor(tbNameUser.Text, tbEmailUser.Text, regio, 1, true);
                doctorContainer.CreateDoctor(doctor, tbPasswordUser.Text);
                MessageBox.Show("Arts toegevoegd");
                lbDoctors.Items.Add(doctor);
                lbDoctors.Items.Clear();
                LoadDoctors();
            }
        }
        private void LoadDoctors()
        {
            lbDoctors.Items.Clear();
            var doctors = doctorContainer.GetAllDoctors();
            foreach (var doctor in doctors)
            {
                lbDoctors.Items.Add(doctor);
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (lbDoctors.SelectedItem == null)
            {
                MessageBox.Show("Selecteer een arts om te verwijderen");
            }
            else
            {
                Doctor doctor = (Doctor)lbDoctors.SelectedItem;
                doctorContainer.DeleteDoctor(doctor.ID);
                MessageBox.Show("Product deleted");
                lbDoctors.Items.Clear();
                LoadDoctors();
            }
        }
    }
}
