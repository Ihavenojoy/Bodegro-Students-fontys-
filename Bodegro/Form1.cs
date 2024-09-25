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
        MessageBox.Show(Convert.ToString(Generate.OTP));
        MessageBox.Show(Convert.ToString(Generate.RandomKey));
        MessageBox.Show(Convert.ToString(Code32.Encode(Generate.RandomKey(32))));
        }
    }
