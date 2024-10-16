using BLL.Containers;
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
        Protocol protocol;
        StepContainer stepContainer = new StepContainer();
        public AddStepForm(Admin admin, Protocol protocol)
        {
            InitializeComponent();
            this.admin = admin;
            this.protocol = protocol;
        }

        private void AddStep_Click(object sender, EventArgs e)
        {
            if (NameBox.Text != null && OrderBox.Value > 0 && IntervalBox.Value > 0 && DescriptionBox.Text != null && TestenBox.Text != null)
            {
                stepContainer.AddStep(NameBox.Text, DescriptionBox.Text, Convert.ToInt32(IntervalBox.Value), Convert.ToInt32(OrderBox.Value), TestenBox.Text);
                this.Close();
            }
        }
    }
}
