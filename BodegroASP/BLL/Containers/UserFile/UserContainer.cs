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
            if (string.IsNullOrWhiteSpace(emailInput) || string.IsNullOrWhiteSpace(passwordInput))
            {
                Console.WriteLine("Email and password must not be empty.");
                return null;
            }
            UserDTO userDTO = _UserService.UserLogin(emailInput);
            var passwordCheck = _UserService.GetHashByEmail(emailInput);
            if (!PasswordHelper.ValidatePassword(passwordInput, passwordCheck))
            {
                Console.WriteLine("Password is incorrect.");
                return null;
            }
            if (userDTO == null || userDTO.ID <= 0)
            {
                Console.WriteLine("No user found with the provided credentials.");
                return null;
            }
            User user = docconverter.DTOToObject(userDTO);
            if (user == null)
            {
                Console.WriteLine("Failed to convert user data.");
                return null;
            }
            return user;
        }


        public bool CreateUser(User User, string password)
        {
            if (_UserService.UserExists(User.Email))
            {
                return false;
            }
            else
            {
                // Hash the password before sending it to the user service
                string hashedPassword = PasswordHelper.HashPassword(password);
                // Assuming CreateUser in UserService takes the password as a parameter
                return _UserService.CreateUser(Userconverter.ObjectToDTO(User), hashedPassword);
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
            // Hash the password before sending it to the user service
            string hashedPassword = PasswordHelper.HashPassword(password);
            // Assuming CreateUser in UserService takes the password as a parameter
            return _UserService.UpdateUser(Userconverter.ObjectToDTO(User), hashedPassword);
        }
    }
}
