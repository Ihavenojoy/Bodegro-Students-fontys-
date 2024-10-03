﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BodegroBusinessLayer.Containers;
using BodegroBusinessLayer.Modules;
namespace Bodegro
{
    public partial class NewSubscription : Form
    {
        NewSubscriptionDomain domain;
        public NewSubscription(Doctor doctor)
        {
            InitializeComponent();
            domain = new NewSubscriptionDomain(doctor);
            Doctor newdoctor = doctor;
            UpdateUI();
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            MessageBox.Show(domain.AddSubscription(ProtocolBox.Text, PatientBox.Text, StartDate.Value, EndDate.Value));
        }
        private void UpdateUI()
        {
            PatientBox.DataSource = domain.GivePatients();
            ProtocolBox.DataSource = domain.GiveProtocols();
        }
    }
}