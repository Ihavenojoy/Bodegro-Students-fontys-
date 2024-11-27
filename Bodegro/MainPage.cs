using DAL;
using Domain.Containers.UserFile;
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
        private UserContainer _UserContainer;
        private User user;
        private User User;
        private readonly IConfiguration iConfiguration;

        public MainPage(User person)
        {
            PatientDAL ipatient = new PatientDAL(iConfiguration);
            UserDAL iUser = new UserDAL(iConfiguration);
            _patientcontainer = new PatientContainer(ipatient);
            _UserContainer = new UserContainer(iUser);
            user = person;
            FirstUser();
            InitializeComponent();
            UpdateUI();


        }
        private void UpdateUI()
        {
            PatientListBox.Items.Clear();
            ComboUserBox.Items.Clear();
            foreach (var sub in PatiëntFill())
            {
                PatientListBox.Items.Add(sub);
            }
            foreach (var sub in Userfill(user))
            {
                ComboUserBox.Items.Add(sub);
                ComboUserBox.Select(0, 0);
            }
        }
        private List<User> Userfill(User user)
        {
            List<User> list = new List<User>();

            if (user is User)
            {
                foreach (User User in _UserContainer.GetAllUsers())
                {
                    list.Add(User);
                }
            }
            else if (user is User)
            {
                list.Add((User)user);
            }
            return list;
        }
        private List<Patient> PatiëntFill()
        {
            List<Patient> list = new List<Patient>();
            foreach (Patient patient in _patientcontainer.GetPatientsOfUser(User))
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
            NewSubscription newSubscription = new(User);
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
            if (user is User)
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

        private void CreateUserButton_Click(object sender, EventArgs e)
        {
            if (user is User)
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

        private void ComboUserBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            User = (User)ComboUserBox.SelectedItem;
            UpdateUI();
        }
        public void FirstUser()
        {
            if (user is User)
            {
                User = (User)user;
            }
            else if (user is User)
            {
                User = _UserContainer.GetAllUsers()[0];
            }
        }

        private void MainPage_Load(object sender, EventArgs e)
        {

        }

        private void LinkArtsAanDoktor_Click(object sender, EventArgs e)
        {
            LinkArtsAanPatient link  = new LinkArtsAanPatient();
            this.Hide();
            if (link.ShowDialog() == DialogResult.OK)
            {

            }
            this.Show();
        }
    }
}

