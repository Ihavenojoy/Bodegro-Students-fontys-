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
        SubscriptionContainer SubscriptionDomain;
        PatientContainer PatientDomain;
        ProtocolContainer ProtocolDomain;
        Doctor doctor;
        public NewSubscription(Doctor doctor)
        {
            InitializeComponent(); 
            SubscriptionDAL subscriptionDAL = new();
            PatientDAL patientDAL = new();
            ProtocolDAL protocolDAL = new();
            SubscriptionDomain = new(doctor, subscriptionDAL, patientDAL, protocolDAL);
            PatientDomain = new(patientDAL);
            ProtocolDomain = new(protocolDAL);
            this.doctor = doctor;
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
            foreach (var sub in PatientDomain.GetPatientsOfDoctor(doctor))
            {
                PatientBox.Items.Add(sub);
            }
        }
        public bool Datumcheck(DateTime StartDate, DateTime EndDate)
        {
            bool check = false;
            if (StartDate.Year < EndDate.Year)
            {
                check = true;
            }
            else if (StartDate.Month < EndDate.Month && StartDate.Year <= EndDate.Year)
            {
                check = true;
            }
            else if (StartDate.Day < EndDate.Day && StartDate.Month <= EndDate.Month && StartDate.Year <= EndDate.Year)
            {
                check = true;
            }
            else if (StartDate.Hour < EndDate.Hour && StartDate.Day <= EndDate.Day && StartDate.Month <= EndDate.Month && StartDate.Year <= EndDate.Year)
            {
                check = true;
            }
            else if (StartDate.Minute < EndDate.Minute && StartDate.Hour <= EndDate.Hour && StartDate.Day <= EndDate.Day && StartDate.Month <= EndDate.Month && StartDate.Year <= EndDate.Year)
            {
                check = true;
            }
            else if (StartDate.Second < EndDate.Second && StartDate.Minute <= EndDate.Minute && StartDate.Hour <= EndDate.Hour && StartDate.Day <= EndDate.Day && StartDate.Month <= EndDate.Month && StartDate.Year <= EndDate.Year)
            {
                check = true;
            }
            return check;
        }
    }
}
