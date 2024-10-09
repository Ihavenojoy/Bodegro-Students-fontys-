using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record AdminDTO : UserDTO
    {
        public AdminDTO(int ID, string Name, string Email) : base(ID, Name, Email)
        {
            this.ID = ID;
            this.Name = Name;
            this.Email = Email;
        }
    }
}
