using BLL.Containers;
using BLL.Modules;
using BodegroInterfaces;
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
        StepContainer stepContainer = new StepContainer();
        Admin user;
        public AddProtocolForm(Admin user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void AddProtocol_Click(object sender, EventArgs e)
        {
            bool check = true;
            if (NameBox.Text != null && DescriptionBox.Text != null && StepAmount.Value > 0)
            {
                Protocol protocol = new Protocol(NameBox.Text, DescriptionBox.Text, user.ID);
                protocolContainer.AddProtocol(protocol.Name, protocol.Description, user);
                this.Hide();
                List<Step> steps = new List<Step>();
                for (int i = 0; i < StepAmount.Value; i++)
                {
                    AddStepForm addStepForm = new AddStepForm(user, protocol);
                    if (addStepForm.ShowDialog() == DialogResult.OK)
                    {

                    }
                    steps.Add(addStepForm.GetStep());
                }
                int IntervalTime = 365;
                foreach (Step step in steps)
                {
                    if (IntervalTime - step.Interval <= 0)
                    {
                        check = false;
                        break;
                    }
                    else
                    {
                        IntervalTime -= step.Interval;
                    }
                }
                if (check)
                {
                    foreach (Step step in steps)
                    {
                        stepContainer.AddStep(step);
                    }
                    MessageBox.Show("creatie succesvol");
                }
                else
                {
                    MessageBox.Show("ongeldige interval selectie, maak het protocol opnieuw");
                }
                Doctor temp = new Doctor("Tom", "temp@gmail.com", BLL.Enums.Regio.Amsterdam, 0, false);
                Form1 form1 = new Form1();
                form1.Closed += (s, args) => this.Close();
                form1.Show();
            }
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            Doctor temp = new Doctor("Tom", "temp@gmail.com", BLL.Enums.Regio.Amsterdam, 0, false);
            this.Hide();
            Form1 form1 = new Form1();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }
    }
}
