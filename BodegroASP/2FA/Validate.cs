using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twofactor
{
    public static class Validation
    {
        public static bool OTP(string secretKey, string inputCode, int digits = 6, int timeStep = 30, int allowedDrift = 1)
        {
            // Generate TOTP for the current time and a few steps before/after (to allow for clock drift)
            for (int i = -allowedDrift; i <= allowedDrift; i++)
            {
                long currentTime = (DateTimeOffset.UtcNow.ToUnixTimeSeconds() / timeStep) + i;
                var timeBytes = BitConverter.GetBytes(currentTime);
                Array.Reverse(timeBytes);

                // Generate the TOTP for this specific time step
                string generatedCode = Generate.OTP(secretKey, digits);
                if (generatedCode == inputCode)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
