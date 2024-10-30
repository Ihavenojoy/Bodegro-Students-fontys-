using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using Interfaces;
using System.Security.Cryptography.X509Certificates;
using Domain.DTOConverter;
using Domain.ObjectConverter;
using Domain.Modules;

namespace Domain.Containers
{
    public class AdminContainer
    {
        public AdminConverter AdminConverter = new AdminConverter();
        public readonly ILogin _InlogService = new LoginDal();
        public Admin Login(string EmailInput, string PasswordInput)
        {
            AdminDTO admindto = _InlogService.AdminLogin(EmailInput, PasswordInput);
            Admin adminacc = AdminConverter.DTOToObject(admindto);
            return adminacc;
        }
    }
}
