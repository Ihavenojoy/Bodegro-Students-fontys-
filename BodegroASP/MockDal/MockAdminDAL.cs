using DTO;

namespace MockDal
{
    public class MockUserDal
    {
        public object check;
        public List<Object> checklist;
        public bool CreateUser(UserDTO User, string Password)
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
        public UserDTO UserLogin(string Emailinput, string PassWordInput)
        {
            UserDTO User = new UserDTO { ID = 6, Email = Emailinput, Name = "Test" };
            check = User;
            return User;
        }
    }
}
