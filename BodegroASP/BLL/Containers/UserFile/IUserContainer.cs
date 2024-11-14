using Domain.Modules;

namespace Domain.Containers.UserFile
{
    public interface IUserContainer
    {
        User UserLogin(string EmailInput, string PasswordInput);
    }
}