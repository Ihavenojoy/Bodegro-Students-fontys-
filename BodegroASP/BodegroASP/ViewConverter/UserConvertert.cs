using BodegroASP.Models;
using Domain.Modules;

namespace BodegroASP.ViewConverter
{
    public class UserConvertert
    {
        public List<UserViewModel> ListObjectToVieuw(List<User> users)
        {
            List<UserViewModel> list = new List<UserViewModel>();
            foreach (User user in users)
            {
                UserViewModel temp = new UserViewModel()
                {
                    ID = user.ID,
                    Name = user.Name,
                    Email = user.Email,
                    Role = (int)user.Role,
                };
                list.Add(temp);
            }
            return list;
        }
    }
}
