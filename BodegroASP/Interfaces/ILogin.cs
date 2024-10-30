using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodegroInterfaces
{
    public interface ILogin
    {
        public DoctorDTO DoctorLogin(string Emailinput, string PassWordInput);
        public AdminDTO AdminLogin(string Emailinput, string PassWordInput);
    }
}
