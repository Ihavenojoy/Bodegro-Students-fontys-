using DAL.DAL_s;
using Domain.Modules;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Converters
{
    public class TwoFactorConverter
    {
        public TwoFactor DTOToObject(TwoFactorDTO twowactorDTO)
        {
            TwoFactor patient = new TwoFactor(
                twowactorDTO.UserId,
                twowactorDTO.OTP,
                twowactorDTO.RequestTime);
            return patient;
        }
        public List<TwoFactor> DTOListToObjectList(List<TwoFactorDTO> twowactorDTO)
        {
            List<TwoFactor> list = [];
            foreach (var twofactors in twowactorDTO)
            {
                TwoFactor twofactor = new TwoFactor(
                    twofactors.UserId,
                twofactors.OTP,
                twofactors.RequestTime);
                list.Add(twofactor);
            }
            return list;
        }
        public TwoFactorDTO ObjectToDTO(TwoFactor twofactor)
        {
            return new TwoFactorDTO
            {
                UserId = twofactor.UserId,
                OTP = twofactor.OTP,
                RequestTime = twofactor.RequestTime,
            };
        }
    }
}
