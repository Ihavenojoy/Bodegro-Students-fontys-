namespace Bodegro;
using BodegroDatabaseLayer;
using Bodegro2FALibrary;
using BodegroBusinessLayer.Enums;
using BodegroBusinessLayer.Modules;

public partial class Form1 : Form
    {
    public Doctor doctor = new Doctor("Henry", "Test3!", "test@gmail.com", Regio.Hart_voor_Brabant);
        public Form1()
        {
            InitializeComponent();
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
        DatabaseConnection databaseConnection = new DatabaseConnection(); // Create object Databaseconnectie
        MessageBox.Show(databaseConnection.OpenConnection()); //
        //MessageBox.Show(Convert.ToString(Generate.OTP)); // Greate OTP without key (does nothing)
        //MessageBox.Show(Convert.ToString(Generate.RandomKey)); //Generates Key (not stringable)
        MessageBox.Show(Convert.ToString(Code32.Encode(Generate.RandomKey(32)))); // Generates a Readable Key
        MessageBox.Show(Generate.OTP(Code32.Encode(Generate.RandomKey(32)),6,30)); // Generates a OTP
        this.Hide();
        NewSubscription newSubscription = new NewSubscription(doctor);
        newSubscription.Closed += (s, args) => this.Close();
        newSubscription.Show();
        InlogPagina inlog = new InlogPagina();
        if (inlog.ShowDialog() == DialogResult.OK && inlog.inlog == true)
        {

        }
    }
    }
