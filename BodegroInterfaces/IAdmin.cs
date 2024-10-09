namespace BodegroInterfaces;
using DTO;
    public interface IAdmin
    {
        public int CreateAdmin(AdminDTO admin, string Password);

        public AdminDTO AdminLogin(string UserNameInput, string PassWordInput);
    }
