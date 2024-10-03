using BodegroBusinessLayer.Modules;
using BodegroBusinessLayer.Containers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BodegroBusinessLayer;
namespace Bodegro
{
    public partial class NewSubscription : Form
    {
        NewSubscriptionContainer domain;
        public NewSubscription(Doctor doctor)
        {
            InitializeComponent();
            domain = new NewSubscriptionContainer(doctor);
            UpdateUI();
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            MessageBox.Show(domain.AddSubscription(ProtocolBox.Text, PatientBox.Text, StartDate.Value, EndDate.Value));
        }
        private void UpdateUI()
        {
            foreach(var sub in domain.GetProtocols())
            {
                ProtocolBox.Items.Add(sub);
            }
            foreach(var sub in domain.GetPatients())
            {
                PatientBox.Items.Add(sub);
            }
            //PatientBox.DataSource = domain.GetPatients();
            //ProtocolBox.DataSource = domain.GetProtocols();
        }
    }
}
