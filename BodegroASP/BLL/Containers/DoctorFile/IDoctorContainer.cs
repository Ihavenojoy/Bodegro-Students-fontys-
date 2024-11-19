using Domain.Modules;

namespace Domain.Containers.UserFile
{
    public interface IUserContainer
    {
        bool CreateUser(User User, string password);
        bool DeleteUser(int UserId);
        bool UserExists(string email);
        List<User> GetAllUsers();
    }
}