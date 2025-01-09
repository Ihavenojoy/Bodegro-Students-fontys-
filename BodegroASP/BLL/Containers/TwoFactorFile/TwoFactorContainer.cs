using Domain.Converter;
using Domain.Converters;
using Domain.Modules;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Twofactor;

namespace Domain.Containers.TwoFactorFile
{

    public class TwoFactorContainer
    {
        private ITwoFactor Dal;
        private TwoFactorConverter converter = new();
        public TwoFactorContainer(ITwoFactor dal)
        {
            Dal = dal;
        }
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        public bool Create(int userid)
        {
            string code = Code32.Encode(Generate.RandomKey(6));
            return Dal.Create(userid, code, DateTime.Now);
=======
        public bool Create(int userid, string usermail, DateTime senttime)
        {
            return Dal.Create(userid, usermail, senttime);
>>>>>>> Stashed changes
=======
        public bool Create(int userid, string usermail, DateTime senttime)
        {
            return Dal.Create(userid, usermail, senttime);
>>>>>>> Stashed changes
        }
        public bool Remove(int userid)
        {
            return Dal.Remove(userid);
        }
        public bool check(int userid, string password)
        {
            return Validation.OTP(Dal.GetById(userid).OTP,Generate.OTP(Dal.GetById(userid).OTP), Dal.GetById(userid).RequestTime);
        }
        public bool Exist(int userid)
        {
            return Dal.Exist(userid);
        }
        public async Task<List<TwoFactor>> GetAll()
        {
            var list = await Dal.GetAll();
            return  converter.DTOListToObjectList(list);
        }
        public bool Send (string OTP, string mail)
        {
            return mail.SentTwofactor(OTP, mail);
        }
        public bool Send (string OTP, string mail)
        {
            return mail.SentTwofactor(OTP, mail);
        }
    }
}
