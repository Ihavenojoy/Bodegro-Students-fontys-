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
    public partial class AddPatientToDoctor : Form
    {
        PatientContainer patientContainer;
        DoctorContainer doctorContainer;

        List<Patient> allPatients;
        List<Doctor> allDoctors;
        public AddPatientToDoctor()
        {
            patientContainer = new PatientContainer(new PatientDAL());
            doctorContainer = new DoctorContainer(new DoctorDAL());
            InitializeComponent();
        }

        private void AddPatientToDoctor_Load(object sender, EventArgs e)
        {
            allPatients = patientContainer.GetAllPatients();
            allDoctors = doctorContainer.GetAllDoctors();
        }
    }
}
