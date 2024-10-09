using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodegroInterfaces
{
    public interface IDoctor
    {
        public int CreateDoctor(DoctorDTO doctor, string Password);
        public DoctorDTO DoctorLogin(string UserNameInput, string PassWordInput);
    }
}
