using DAL.DAL_s;
using Domain.Containers._2FAFile;
using Domain.Modules;

namespace BodegroASP.BackGroundServices.TwoFactorTask
{
    public class TwoFactorDone
    {
        IConfiguration _configuration;
        public _2FAContainer container;
        public TwoFactorDone()
        {
            container = new _2FAContainer(new TwoFactorDAL(_configuration));
        }
        public async Task ValidTwoFactorCheck()
        {
            List<TwoFactor> twofactos = await container.GetAll();
            foreach (TwoFactor factor in twofactos)
            {
                int secondsappart = (int)(DateTime.Now - factor.RequestTime).TotalSeconds;
                if (secondsappart > 300)
                {
                    container.Remove(factor.UserId);
                }
            }
        }
    }
}
