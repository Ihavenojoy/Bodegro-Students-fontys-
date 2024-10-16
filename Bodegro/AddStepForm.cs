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
        Protocol protocol;
        Step step;
        public AddStepForm(Protocol protocol)
        {
            InitializeComponent();
            this.protocol = protocol;
        }

        private void AddStep_Click(object sender, EventArgs e)
        {
            if (NameBox.Text != null && OrderBox.Value >= 0 && IntervalBox.Value > 0 && DescriptionBox.Text != null && TestenBox.Text != null)
            {
                step = new Step(protocol.ID, NameBox.Text, DescriptionBox.Text, Convert.ToInt32(OrderBox.Value), TestenBox.Text, Convert.ToInt32(IntervalBox.Value));
                this.Close();
            }
            else
            {
                MessageBox.Show("Niet alle gegevens zijn ingevuld");
            }
        }
        public Step GetStep()
        {
            return step;
        }
    }
}
