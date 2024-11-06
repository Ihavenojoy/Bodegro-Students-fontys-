using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Twofactor;

namespace Bodegro
{
    public partial class TwoFactorPage : Form
    {
        public bool Confirmation = false;
        public byte[] encodedkey = Generate.RandomKey(32);
        public TwoFactorPage()
        {
            InitializeComponent();
            //MessageBox.Show(Convert.ToString(Code32.Encode(Generate.RandomKey(32)))); // Generates a Readable Key
            MessageBox.Show(Generate.OTP(Code32.Encode(Generate.RandomKey(32)), 6, 30)); // Generates a OTP
            TwoFactorUserInput.Text = Generate.OTP(Code32.Encode(encodedkey));
        }

        private void TwoFactorSubmitButton_Click(object sender, EventArgs e)
        {
            string OTPInput = TwoFactorUserInput.Text;
            if (OTPInput == Generate.OTP(Code32.Encode(encodedkey)));
            {
                Confirmation = true;
                this.Close();
            }
        }
    }
}
