﻿using BLL.Modules;
using BLL.Containers;
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
        public NewSubscription(Doctor doctor)
        {
            InitializeComponent();
            domain = new SubscriptionContainer(doctor);
            UpdateUI();
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            MessageBox.Show(domain.AddSubscription(ProtocolBox.Text, PatientBox.Text, StartDate.Value));
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

        private void AddProtocol_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddProtocolForm addProtocolForm = new AddProtocolForm();
            addProtocolForm.Closed += (s, args) => this.Close();
            addProtocolForm.Show();
        }
    }
}
