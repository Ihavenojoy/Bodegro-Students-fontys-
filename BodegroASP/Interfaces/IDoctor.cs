using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IDoctor
    {
        public bool CreateDoctor(DoctorDTO doctor, string password);
        public bool DoctorExists(string email);
        public bool SoftDeleteDoctor(int id);
        public List<DoctorDTO> GetAllDoctors();
    }
}
