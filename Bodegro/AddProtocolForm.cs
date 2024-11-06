using Domain.Containers;
using Domain.Modules;
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
using DAL;

namespace Bodegro
{
    public partial class AddProtocolForm : Form
    {
        ProtocolContainer protocolContainer;
        StepContainer stepContainer;
        Admin user;
        public AddProtocolForm(Admin User)
        {
            ProtocolDAL protocolDAL = new ProtocolDAL();
            protocolContainer = new ProtocolContainer(protocolDAL);
            StepDAL stepDAL = new StepDAL();
            stepContainer = new StepContainer(stepDAL);
            InitializeComponent();
            user = User;
        }
        private void AddProtocol_Click(object sender, EventArgs e)
        {
            if (NameBox.Text != null && DescriptionBox.Text != null && StepAmount.Value > 0)
            {
                List<Step> steps = new List<Step>();
                Protocol protocol = new Protocol(NameBox.Text, DescriptionBox.Text, steps, user.ID);
                protocolContainer.AddProtocol(protocol);
                this.Hide();
                for (int i = 0; i < StepAmount.Value; i++)
                {
                    AddStepForm addStepForm = new AddStepForm(protocol);
                    if (addStepForm.ShowDialog() == DialogResult.OK)
                    {

                    }
                    protocol.Steps.Add(addStepForm.GetStep());
                }
                ErrorCheck(protocol.Steps);
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
        private void ErrorCheck(List<Step> steps)
        {
            bool IntervalCheck = true;
            bool OrderCheck = true;
            int IntervalTime = 365;

            foreach (Step step in steps)
            {
                if (IntervalTime - step.Interval <= 0)
                {
                    IntervalCheck = false;
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
                        if (step.Name != steps[i].Name)
                        {
                            OrderCheck = false;
                        }
                    }
                }
            }
            if (IntervalCheck && OrderCheck)
            {
                foreach (Step step in steps)
                {
                    stepContainer.AddStep(step);
                }
                MessageBox.Show("creatie succesvol");
            }
            else if (!IntervalCheck)
            {
                MessageBox.Show("ongeldige interval selectie, maak het protocol opnieuw");
            }
            else if (!OrderCheck)
            {
                MessageBox.Show("een ordernummer komt meerdere keren voor, maak het protocol opnieuw");
            }
        }
    }
}
