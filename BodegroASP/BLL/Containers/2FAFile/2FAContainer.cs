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

namespace Domain.Containers._2FAFile
{

    public class _2FAContainer
    {
        private ITwoFactor Dal;
        private TwoFactorConverter converter = new();
        public _2FAContainer(ITwoFactor dal)
        {
            Dal = dal;
        }
        public bool Create(int userid)
        {
            string code = Code32.Encode(Generate.RandomKey(6));
            return Dal.Create(userid, code, DateTime.Now);
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
            return  converter.DTOListToObjectList(list);
        }
    }
}
