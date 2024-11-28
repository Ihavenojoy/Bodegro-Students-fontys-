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
        public UserDTO UserLogin(string Emailinput);
        public void TwofactorActivation(string UserEmail);
        public bool TwofactorCheck(string Userinput);
        public bool CreateUser(UserDTO User, string password);
        public bool UserExists(string email);
        public bool SoftDeleteUser(int id);
        public List<UserDTO> GetAllUsers();
        public UserDTO GetUserByID(int id);
        public bool UpdateUser(UserDTO user, string password);
        string GetHashByEmail(string email);
    }
}
