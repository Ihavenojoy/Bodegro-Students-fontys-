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
        ProtocolContainer protocolContainer = new ProtocolContainer();
        Admin user;
        public AddProtocolForm(Admin user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void AddProtocol_Click(object sender, EventArgs e)
        {
            if (NameBox.Text != null && DescriptionBox.Text != null && StepAmount.Value > 0)
            {
                Protocol protocol = new Protocol(NameBox.Text, DescriptionBox.Text, user.ID);
                protocolContainer.AddProtocol(protocol.Name, protocol.Description, user);
                this.Hide();
                for (int i = 0; i < StepAmount.Value; i++)
                {
                    AddStepForm addStepForm = new AddStepForm(user, protocol);
                    addStepForm.Show(); 
                    if (addStepForm.ShowDialog() == DialogResult.OK)
                    {

                    }
                }
                Doctor temp = new Doctor("Tom", "temp@gmail.com", BLL.Enums.Regio.Amsterdam, 0, false);
                NewSubscription newSubscription = new NewSubscription(temp);
                newSubscription.Closed += (s, args) => this.Close();
                newSubscription.Show();
            }
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            Doctor temp = new Doctor("Tom", "temp@gmail.com", BLL.Enums.Regio.Amsterdam, 0, false);
            this.Hide();
            NewSubscription newSubscription = new NewSubscription(temp);
            newSubscription.Closed += (s, args) => this.Close();
            newSubscription.Show();
        }
    }
}
