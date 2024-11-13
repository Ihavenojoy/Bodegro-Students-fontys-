using BLL.Modules;
using DAL;
using Domain.Containers;
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
        List<Patient> allPatients;
        public AddPatientToDoctor()
        {
            patientContainer = new PatientContainer(new PatientDAL());
            InitializeComponent();
        }

        private void AddPatientToDoctor_Load(object sender, EventArgs e)
        {
            allPatients = patientContainer.GetAllPatients();
        }
    }
}
