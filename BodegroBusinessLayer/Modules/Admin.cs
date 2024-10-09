using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL.Modules
{
    public class Admin : User
    {
        public Admin(int ID, string Name, string Email) : base(ID, Name, Email)
        {

        }

    }

}
