using Domain.Enums;
using Domain.Modules;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Domain.Converter
{
    public class UserConverter
    {
        public User DTOToObject(UserDTO dto)
        {
            User User = new User(
                dto.ID,
                dto.Name,
                dto.Email,
                (Role)dto.Role,
                dto.IsActive
            );
            return User;
        }
        public UserDTO ObjectToDTO(User User)
        {
            return new UserDTO
            {
                ID = User.ID,
                Name = User.Name,
                Email = User.Email,
                Role = (int)User.Role,
                IsActive = User.IsActive
            };
        }
    }
}
