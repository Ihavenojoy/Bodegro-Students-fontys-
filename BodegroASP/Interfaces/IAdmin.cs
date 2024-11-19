namespace Interfaces;
using DTO;
    public interface IAdmin
    {
        public bool CreateAdmin(AdminDTO admin, string Password);

        public AdminDTO AdminLogin(string UserNameInput, string PassWordInput);
    }
