using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockDal
{
    public class MockUserDal
    {
        public object check;
        public List<Object> checklist;
        public bool CreateUser(UserDTO User, string password)
        {
            if (User != null)
            {
                check = User;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UserExists(string email)
        {
            if (email != null)
            {
                check = email;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
