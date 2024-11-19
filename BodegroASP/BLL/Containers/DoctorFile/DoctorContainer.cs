using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Domain.Modules;
using DTO;
using Domain.Converter;
using Interfaces;
using System.Data;

namespace Domain.Containers.UserFile
{
    public class UserContainer : IUserContainer
    {
        UserConverter docConverter;
        IUser UserDAL;
        public UserContainer(IUser DAL, UserConverter docConverter)
        {
            UserDAL = DAL;
            this.docConverter = docConverter;
        }
        public bool CreateUser(User User, string password)
        {
            if (UserDAL.UserExists(User.Email))
            {
                return false;
            }
            else
            {
                return UserDAL.CreateUser(docConverter.ObjectToDTO(User), password);
            }
        }
        public bool UserExists(string email)
        {
            return UserDAL.UserExists(email);
        }
        public bool DeleteUser(int UserId)
        {
            bool isDeleted = UserDAL.SoftDeleteUser(UserId);
            if (!isDeleted)
            {
                return false;
            }
            return true;
        }


        public List<User> GetAllUsers()
        {
            List<User> Users = new();
            List<UserDTO> UserDTOS = UserDAL.GetAllUsers();

            foreach (UserDTO User in UserDTOS)
            {
                Users.Add(docConverter.DTOToObject(User));
            }
            return Users;
        }



    }
}
