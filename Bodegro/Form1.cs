namespace Bodegro;
using BodegroDatabaseLayer;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
        DatabaseConnection databaseConnection = new DatabaseConnection();
        databaseConnection.OpenConnection();
        }
    }
