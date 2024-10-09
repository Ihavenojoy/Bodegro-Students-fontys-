using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record AdminDTO : UserDTO
    {
        public AdminDTO(string username, string email) : base (username, email) 
        {

        }
    }

}
