using Domain.Converters;
using Domain.Modules;
using Domain.Services;
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
            if (!Dal.Exist(userid))
            {
                string code = Code32.Encode(Generate.RandomKey(6));
                if (Dal.Create(userid, code, DateTime.Now));
                {
                    return mail.SentTwofactor(code, usermail); 
                }
                
            }
            else
            {
                return mail.SentTwofactor(Dal.GetById(userid).OTP,usermail); 
            }

        }
        public bool Remove(int userid)
        {
            return Dal.Remove(userid);
        }
        public bool check(int userid, string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            return Dal.Check(userid, Code32.Encode(passwordBytes));
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
    }
}
