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
    public partial class AddProtocolForm : Form
    {
        ProtocolContainer protocolContainer;
        Admin user;
        public AddProtocolForm(Admin user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void AddProtocol_Click(object sender, EventArgs e)
        {
            if (NameBox.Text != null && ProtocolSteps.Items.Count > 0)
            {
                List<Step> steps = new List<Step>();
                foreach (var sub in ProtocolSteps.Items)
                {
                    if (sub is Step)
                    {
                        steps.Add((Step)sub);
                    }
                }
                protocolContainer.AddProtocol(NameBox.Text, DescriptionBox.Text, steps, user);
            }
        }
        private void NewStep_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddStepForm addStepForm = new AddStepForm();
            addStepForm.Closed += (s, args) => this.Close();
            addStepForm.Show();
        }
        private void UpdateUI()
        {

        }
    }
}
