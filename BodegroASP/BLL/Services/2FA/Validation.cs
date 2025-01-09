﻿using Domain.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twofactor
{
    public static class Validation
    {
        public static bool OTP(string secretKey, string inputCode, DateTime requesttime, int digits = 6, int timeStep = 30, int allowedDrift = 1)
        {
            // Generate TOTP for the current time and a few steps before/after (to allow for clock drift)
            for (int i = -allowedDrift; i <= allowedDrift; i++)
            {
                DateTimeOffset DateTimeRequest = new DateTimeOffset(requesttime);
                long currentTime = (DateTimeRequest.ToUnixTimeSeconds() / timeStep) + i;
                var timeBytes = BitConverter.GetBytes(currentTime);
                Array.Reverse(timeBytes);

                // Generate the TOTP for this specific time step
                string generatedCode = Generate.OTP(secretKey, requesttime);
                if (generatedCode == inputCode)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
