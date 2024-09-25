namespace Bodegro;
using BodegroDatabaseLayer;
using Bodegro2FALibrary;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
        DatabaseConnection databaseConnection = new DatabaseConnection();
        MessageBox.Show(databaseConnection.OpenConnection());
        MessageBox.Show(Convert.ToString(Generate.OTP)); // Greate OTP without key (does nothing)
        MessageBox.Show(Convert.ToString(Generate.RandomKey)); //Generates Key (not stringable)
        MessageBox.Show(Convert.ToString(Code32.Encode(Generate.RandomKey(32)))); // Generates a Readable Key
        MessageBox.Show(Generate.OTP(Code32.Encode(Generate.RandomKey(32)),6,30)); // Generates a OTP
        }
    }
