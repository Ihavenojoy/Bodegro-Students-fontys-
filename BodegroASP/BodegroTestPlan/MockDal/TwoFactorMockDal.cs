using DTO;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodegroTestPlan.MockDal
{
    public class TwoFactorMockDal : ITwoFactor
    {
        public bool succes = true;
        public object Mockobject1;
        public object Mockobject2;
        public object Mockobject3;
        public List<TwoFactorDTO> MockDTOList;
        private List<TwoFactorDTO> DTOList;
        public TwoFactorMockDal()
        {
            MockDTOList = new List<TwoFactorDTO>();
            DTOList = new List<TwoFactorDTO>()
            {
                new TwoFactorDTO(){OTP = "536904", RequestTime = DateTime.Now, UserId = 24 },
                new TwoFactorDTO(){OTP = "536904", RequestTime = DateTime.Now, UserId = 24 },
                new TwoFactorDTO(){OTP = "536904", RequestTime = DateTime.Now, UserId = 24 }
            };
        }

        public bool Check(int userid, string passwordinput)
        {
            Mockobject1 = userid;
            Mockobject2 = passwordinput;
            return succes;
        }

        public bool Create(int userid, string key, DateTime senttime)
        {
            Mockobject1 = userid;
            Mockobject2 = key;
            Mockobject3 = senttime;
            return succes;
        }

        public bool Exist(int userid)
        {
            Mockobject1 = userid;
            return succes;
        }

        public Task<List<TwoFactorDTO>> GetAll()
        {
            MockDTOList = DTOList;
            return Task.FromResult(DTOList);
        }

        public bool Remove(int userid)
        {
            Mockobject1 = userid;
            return succes;
        }
    }
}
