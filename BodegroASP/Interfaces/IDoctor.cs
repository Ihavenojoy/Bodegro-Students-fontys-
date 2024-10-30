using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodegroInterfaces
{
    public interface IDoctor
    {
        public int CreateDoctor(DoctorDTO doctor, string password);
        public bool DoctorExists(string email);
        public bool SoftDeleteDoctor(int id);
        public List<DoctorDTO> GetAllDoctors();
    }
}
