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
            bool check1 = true;
            bool check2 = true;
            if (NameBox.Text != null && DescriptionBox.Text != null && StepAmount.Value > 0)
            {
                Protocol protocol = new Protocol(NameBox.Text, DescriptionBox.Text, user.ID);
                protocolContainer.AddProtocol(protocol.Name, protocol.Description, user);
                this.Hide();
                List<Step> steps = new List<Step>();
                for (int i = 0; i < StepAmount.Value; i++)
                {
                    AddStepForm addStepForm = new AddStepForm(protocol);
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
                        check1 = false;
                        break;
                    }
                    else
                    {
                        IntervalTime -= step.Interval;
                    }
                    for (int i = 0; i < steps.Count; i++) 
                    {
                        if (step.Order == steps[i].Order)
                        {
                            check2 = false;
                        }
                    }
                }
                if (check1 && check2)
                {
                    foreach (Step step in steps)
                    {
                        stepContainer.AddStep(step);
                    }
                    MessageBox.Show("creatie succesvol");
                }
                else if (check2)
                {
                    MessageBox.Show("ongeldige interval selectie, maak het protocol opnieuw");
                }
                else if (check1)
                {
                    MessageBox.Show("een ordernummer komt meerdere keren voor, maak het protocol opnieuw");
                }
                Form1 form1 = new Form1();
                form1.Closed += (s, args) => this.Close();
                form1.Show();
            }
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }
    }
}
