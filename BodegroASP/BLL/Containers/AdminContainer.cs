using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BLL;
using DTO;
using BodegroInterfaces;
using System.Security.Cryptography.X509Certificates;
using BLL.DTOConverter;
using BLL.ObjectConverter;
using BLL.Modules;

namespace Domain.Containers
{
    public class AdminContainer
    {
        public AdminConverter AdminConverter = new AdminConverter();
        public readonly ILogin _InlogService = new LoginDal();
        IAdmin AdminDAL;
        public AdminContainer(AdminDAL DAL)
        {
            AdminDAL = DAL;
        }
        public Admin Login(string EmailInput, string PasswordInput)
        {
            AdminDTO admindto = _InlogService.AdminLogin(EmailInput, PasswordInput);
            Admin adminacc = AdminConverter.DTOToObject(admindto);
            return adminacc;
        }
    }
}
