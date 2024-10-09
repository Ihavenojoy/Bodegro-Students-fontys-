using BLL.Containers;
using BLL.Modules;
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
    public partial class PatiëntRegistry : Form
    {
        private PatientContainer _container;
        private User user;
        public PatiëntRegistry(User user)
        {
            InitializeComponent();
            UpdateUI();
            this.user = user;
        }
        private void UpdateUI()
        {
            PatiëntBox.Items.Clear();
            foreach (var sub in PatiëntFill())
            {
                PatiëntBox.Items.Add(sub);
            }
        }
        private List<Patient> PatiëntFill()
        {
            List<Patient> list = new List<Patient>();
            foreach (Patient patient in _container.AskAllPatientsOfDoctor(user))
            {
                list.Add(patient);
            }
            return list;
        }
    }
}
