using DAL;
using Domain.Converter;
using Domain.Modules;
using DTO;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Containers.UserFile
{
    public class UserContainer : IUserContainer
    {
        private readonly IUser _UserService;
        UserConverter docconverter = new UserConverter();
        UserConverter Userconverter = new UserConverter();
        public UserContainer(IUser context)
        {
            _UserService = context;
        }

        public User UserLogin(string emailInput, string passwordInput)
        {
            UserDTO userDTO = _UserService.UserLogin(emailInput, passwordInput);
            if (userDTO != null)
            {
                User userAccount = docconverter.DTOToObject(userDTO);
                return userAccount;
            }
            else
            {
                // Handle the case where login is unsuccessful
                // Log the error or handle it according to your application's requirements
                return null;
            }
        }


        public bool CreateUser(User User, string password)
        {
            if (_UserService.UserExists(User.Email))
            {
                return false;
            }
            else
            {
                return _UserService.CreateUser(Userconverter.ObjectToDTO(User), password);
            }
        }
        public bool UserExists(string email)
        {
            return _UserService.UserExists(email);
        }
        public bool DeleteUser(int UserId)
        {
            bool isDeleted = _UserService.SoftDeleteUser(UserId);
            if (!isDeleted)
            {
                return false;
            }
            return true;
        }


        public List<User> GetAllUsers()
        {
            List<User> Users = new();
            List<UserDTO> UserDTOS = _UserService.GetAllUsers();

            foreach (UserDTO User in UserDTOS)
            {
                Users.Add(docconverter.DTOToObject(User));
            }
            return Users;
        }
        public User GetUserByID(int UserId)
        {
            UserDTO UserDTO = _UserService.GetUserByID(UserId);
            User User = docconverter.DTOToObject(UserDTO);
            return User;
        }
        public bool UpdateUser(User User, string password)
        {
            return _UserService.UpdateUser(Userconverter.ObjectToDTO(User), password);
        }
    }
}
