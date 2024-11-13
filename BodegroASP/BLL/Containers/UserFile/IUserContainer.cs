using Domain.Modules;

namespace Domain.Containers.UserFile
{
    public interface IUserContainer
    {
        Admin AdminLogin(string EmailInput, string PasswordInput);
        Doctor DoctorLogin(string EmailInput, string PasswordInput);
    }
}