using DAL;
using Domain.Converters;
using Domain.Modules;
using DTO;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Containers
{
    public class UserContainer
    {
        private readonly IUser _InlogService;
        DoctorConverter docconverter = new DoctorConverter();
        AdminConverter adminconverter = new AdminConverter();
        public UserContainer(IUser context)
        {
            _InlogService = context;
        }

        public Doctor DoctorLogin(string EmailInput, string PasswordInput)
        {
            DoctorDTO doctorDTO = _InlogService.DoctorLogin(EmailInput, PasswordInput);
            Doctor doctoracc = docconverter.DTOToObject(doctorDTO);
            return doctoracc;
        }
        public Admin AdminLogin(string EmailInput, string PasswordInput)
        {
            AdminDTO admindto = _InlogService.AdminLogin(EmailInput, PasswordInput);
            Admin adminacc = adminconverter.DTOToObject(admindto);
            return adminacc;
        }

    }
}
