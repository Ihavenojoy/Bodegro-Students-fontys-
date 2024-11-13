using DAL;
using Domain.Containers.DoctorFile;
using Domain.Containers.PatientFile;
using Domain.Modules;
using Interfaces;
using Microsoft.Extensions.Configuration;
using System.Runtime.ExceptionServices;

namespace Bodegro
{
    public partial class MainPage : Form
    {
        private PatientContainer _patientcontainer;
        private DoctorContainer _doctorContainer;
        private User user;
        private Doctor doctor;
        private readonly IConfiguration iConfiguration;

        public MainPage(User person)
        {
            PatientDAL ipatient = new PatientDAL(iConfiguration);
            DoctorDAL idoctor = new DoctorDAL(iConfiguration);
            _patientcontainer = new PatientContainer(ipatient);
            _doctorContainer = new DoctorContainer(idoctor);
            user = person;
            Firstdoctor();
            InitializeComponent();
            UpdateUI();
            

        }
        private void UpdateUI()
        {
            PatientListBox.Items.Clear();
            ComboDoctorBox.Items.Clear();
            foreach (var sub in PatiëntFill())
            {
                PatientListBox.Items.Add(sub);
            }
            foreach (var sub in Doctorfill(user))
            {
                ComboDoctorBox.Items.Add(sub);
                ComboDoctorBox.Select(0, 0);
            }
        }
        private List<Doctor> Doctorfill(User user)
        {
            List<Doctor> list = new List<Doctor>();

            if (user is Admin)
            {
                foreach (Doctor doctor in _doctorContainer.GetAllDoctors())
                {
                    list.Add(doctor);
                }
            }
            else if (user is Doctor)
            {
                list.Add((Doctor)user);
            }
            return list;
        }
        private List<Patient> PatiëntFill()
        {
            List<Patient> list = new List<Patient>();
            foreach (Patient patient in _patientcontainer.GetPatientsOfDoctor(doctor))
            {
                list.Add(patient);
            }
            return list;
        }

        private void AddPatientButton_Click(object sender, EventArgs e)
        {

        }

        private void AddProtocolToPatientButton_Click(object sender, EventArgs e)
        {
            NewSubscription newSubscription = new(doctor);
            this.Hide();
            if (newSubscription.ShowDialog() == DialogResult.OK)
            {

            }
            this.Show();
        }

        private void CreatePatientButton_Click(object sender, EventArgs e)
        {
            CreateUser createUser = new CreateUser(1, user);
            this.Hide();
            if (createUser.ShowDialog() == DialogResult.OK)
            {

            }
            this.Show();
        }

        private void CreateArtsButton_Click(object sender, EventArgs e)
        {
            if (user is Admin)
            {
                CreateUser createUser = new CreateUser(0, user);
                this.Hide();
                if (createUser.ShowDialog() == DialogResult.OK)
                {

                }
                this.Show();
            }
            else
            {
                MessageBox.Show("Gebruiker is geen beheerder");
            }

        }

        private void CreateAdminButton_Click(object sender, EventArgs e)
        {
            if (user is Admin)
            {
                CreateUser createUser = new CreateUser(0, user);
                this.Hide();
                if (createUser.ShowDialog() == DialogResult.OK)
                {

                }
                this.Show();
            }
            else
            {
                MessageBox.Show("Gebruiker is geen beheerder");
            }

        }

        private void ComboDoctorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            doctor = (Doctor)ComboDoctorBox.SelectedItem;
            UpdateUI();
        }
        public void Firstdoctor()
        {
            if (user is Doctor)
            {
                doctor = (Doctor)user;
            }
            else if (user is Admin)
            {
                doctor = _doctorContainer.GetAllDoctors()[0];
            }
        }
    }
}

