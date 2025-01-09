using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ITwoFactor
    {
        public bool Create(int userid, string key, DateTime senttime);
        public bool Exist(int userid);
        public bool Remove(int userid);
        public Task<List<TwoFactorDTO>> GetAll();
        public bool Check(int userid, string passwordinput);
        public TwoFactorDTO GetById(int userid);
    }
}
