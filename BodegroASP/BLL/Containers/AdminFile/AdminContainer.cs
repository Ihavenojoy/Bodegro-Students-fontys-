using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using Interfaces;
using System.Security.Cryptography.X509Certificates;
using Domain.Converter;
using Domain.Modules;

namespace Domain.Containers.UserFile
{
    public class UserContainer
    {
        public UserConverter UserConverter = new UserConverter();
        IUser UserDAL;
        public UserContainer(IUser DAL)
        {
            UserDAL = DAL;
        }

    }
}
