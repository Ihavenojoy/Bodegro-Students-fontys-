using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Enums;
using DAL;

namespace BLL.Modules
{
    public class Doctor : User
    {
        public Regio Regio { get; set; }
        public List<int> PatientIDs { get; set; }

        public Doctor(string username, string email, Regio regio) : base (username, email)
        {
            this.Regio = regio;
            PatientIDs = new List<int>() { 1 };
        }
        public List<int> GetPatientIDs()
        {
            return PatientIDs;
        }

    }
}
