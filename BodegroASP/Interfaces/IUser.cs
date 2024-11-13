using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IUser
    {
        public DoctorDTO DoctorLogin(string Emailinput, string PassWordInput);
        public AdminDTO AdminLogin(string Emailinput, string PassWordInput);
        public void TwofactorActivation(string UserEmail);
        public bool TwofactorCheck(string Userinput);
    }
}
