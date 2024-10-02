using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodegroLibery
{
    public record AdminDTO : UserDTO
    {
        public AdminDTO(string username, string password, string email) : base (username, password, email) 
        {

        }
    }

}
