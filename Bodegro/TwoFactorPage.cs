using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bodegro
{
    public partial class TwoFactorPage : Form
    {
        public bool Confirmation = false;
        public TwoFactorPage()
        {
            InitializeComponent();
        }

        private void TwoFactorSubmitButton_Click(object sender, EventArgs e)
        {
            string OTPInput = TwoFactorUserInput.Text;
            if (OTPInput == OTPInput)
            {
                Confirmation = true;
                this.Close();
            }
        }
    }
}
