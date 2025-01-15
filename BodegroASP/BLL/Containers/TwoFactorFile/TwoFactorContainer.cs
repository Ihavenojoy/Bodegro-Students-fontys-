using Domain.Converters;
using Domain.Modules;
using Domain.Services;
using DTO;
using Interfaces;
using System.Text;
using Twofactor;

namespace Domain.Containers.TwoFactorFile
{

    public class TwoFactorContainer
    {
        private ITwoFactor Dal;
        private TwoFactorConverter converter = new();
        private MailServicesTwoFactor mail = new MailServicesTwoFactor();

        public TwoFactorContainer(ITwoFactor dal)
        {
            Dal = dal;
        }
        public bool Create(int userid, string usermail)
        {       
         string code = Code32.Encode(Generate.RandomKey(32));
         return Dal.Create(userid, code, DateTime.Now) ;
        }
        public bool Remove(int userid)
        {
            return Dal.Remove(userid);
        }
        public bool check(int userid, string password)
        {
            TwoFactorDTO check = Dal.GetById(userid);
            return Validation.OTP(check.OTP,password, check.RequestTime);
        }
        public bool Exist(int userid)
        {
            return Dal.Exist(userid);
        }
        public async Task<List<TwoFactor>> GetAll()
        {
            var list = await Dal.GetAll();
            return converter.DTOListToObjectList(list);
        }
        public bool Send(int userid, string usermail)
        {
            TwoFactorDTO check = Dal.GetById(userid);
            return mail.SentTwofactor(Generate.OTP(check.OTP, check.RequestTime), usermail);
        }
    }
}
