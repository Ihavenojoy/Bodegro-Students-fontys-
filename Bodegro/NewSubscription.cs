using Domain.Modules;
using Domain.Containers;
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

namespace Bodegro
{
    public partial class NewSubscription : Form
    {
        SubscriptionContainer domain;
        Doctor doctor;
        public NewSubscription(Doctor doctor)
        {
            InitializeComponent(); 
            SubscriptionDAL subscriptionDAL = new SubscriptionDAL();
            PatientDAL patientDAL = new PatientDAL();
            ProtocolDAL protocolDAL = new ProtocolDAL();
            domain = new SubscriptionContainer(doctor, subscriptionDAL, patientDAL, protocolDAL);
            this.doctor = doctor;
            UpdateUI();
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            if (ProtocolBox.SelectedItem is Protocol && PatientBox.SelectedItem is Patient)
            {
                MessageBox.Show(domain.AddSubscription((Protocol)ProtocolBox.SelectedItem, (Patient)PatientBox.SelectedItem, StartDate.Value));
            }
        }
        private void UpdateUI()
        {
            foreach (var sub in domain.GetProtocols())
            {
                ProtocolBox.Items.Add(sub);
            }
            foreach (var sub in domain.GetPatients())
            {
                PatientBox.Items.Add(sub);
            }
        }
    }
}
