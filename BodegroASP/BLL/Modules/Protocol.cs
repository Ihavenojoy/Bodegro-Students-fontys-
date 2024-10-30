using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Domain.Modules
{
    public class Protocol
    {
        public int ID { get;}
        public string Name { get; set; }
        public string Description { get; set; }
        public int Admin_ID { get; set; }

        public Protocol(string Name, string Description, int admin_ID)
        {
            this.Name = Name;
            this.Description = Description;
            Admin_ID = admin_ID;
        }
        public string ToString()
        {
            return Name;
        }
    }
}
