using DAL;
using Domain.Containers;
using Domain.Modules;
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
    public partial class LinkArtsAanPatient : Form
    {
        DoctorContainer dc;
        PatientContainer pc;

        List<Doctor> allDoctors;
        List<Patient> allPatients;
        public LinkArtsAanPatient()
        {
            dc = new DoctorContainer(new DoctorDAL());
            pc = new PatientContainer(new PatientDAL());
            InitializeComponent();
        }

        private void LinkArtsAanPatient_Load(object sender, EventArgs e)
        {
            allDoctors = dc.GetAllDoctors();
            allPatients = pc.GetAllPatients();

            AllDoctorsBox.DataSource = allDoctors;
            AllDoctorsBox.DisplayMember = "Name";

            PatientList.DataSource = allPatients;
            PatientList.DisplayMember = "Name";

        }

        private void AllDoctorsBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PatientList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LinkButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}
