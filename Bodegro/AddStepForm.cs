using BLL.Modules;
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
    public partial class AddStepForm : Form
    {
        Admin admin;
        public AddStepForm(Admin admin)
        {
            InitializeComponent();
            this.admin = admin;
        }

        private void AddStep_Click(object sender, EventArgs e)
        {
            if (NameBox.Text != null && OrderBox.Text != null && IntervalBox.Text != null && DescriptionBox.Text != null && TestenBox.Text != null)
            {


                this.Hide();
                AddProtocolForm addProtocolForm = new AddProtocolForm(admin);
                addProtocolForm.Closed += (s, args) => this.Close();
                addProtocolForm.Show();
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddProtocolForm addProtocolForm = new AddProtocolForm(admin);
            addProtocolForm.Closed += (s, args) => this.Close();
            addProtocolForm.Show();
        }
    }
}
