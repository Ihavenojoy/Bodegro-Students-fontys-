using Domain.Modules;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using Domain.Containers.PatientFile;
using Domain.Containers.ProtocolFile;
using Domain.Containers.SubscriptionFile;

namespace Bodegro
{
    public partial class NewSubscription : Form
    {
        SubscriptionContainer SubscriptionDomain;
        PatientContainer PatientDomain;
        ProtocolContainer ProtocolDomain;
        User User;
        private readonly IConfiguration iConfiguration;
        public NewSubscription(User User)
        {
            InitializeComponent(); 
            SubscriptionDAL subscriptionDAL = new(iConfiguration);
            PatientDAL patientDAL = new(iConfiguration);
            ProtocolDAL protocolDAL = new(iConfiguration);
            SubscriptionDomain = new(User, subscriptionDAL, patientDAL, protocolDAL);
            PatientDomain = new(patientDAL);
            ProtocolDomain = new(protocolDAL, new StepDAL(iConfiguration));
            this.User = User;
            UpdateUI();
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            if (ProtocolBox.SelectedItem is Protocol && PatientBox.SelectedItem is Patient)
            {
                SubscriptionDomain.AddSubscription((Protocol)ProtocolBox.SelectedItem, (Patient)PatientBox.SelectedItem, StartDate.Value);
                MessageBox.Show("Succesvol toegevoegd");
            }
            else
            {
                MessageBox.Show("Er is iets fout gegaan");
            }
        }
        private void UpdateUI(){
            foreach (var sub in ProtocolDomain.GetProtocols())
            {
                ProtocolBox.Items.Add(sub);
            }
            foreach (var sub in PatientDomain.GetPatientsOfUser(User))
            {
                PatientBox.Items.Add(sub);
            }
        }
    }
}
