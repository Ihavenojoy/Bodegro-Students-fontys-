namespace Bodegro2FALibrary;
using System.Security.Cryptography;
public class Generate
{
    // This method generates a TOTP code based on the current time
    public static string OTP(string secretKey, int digits = 6, int timeStep = 30)
    {

        // Get the current timestamp in seconds and divide by time step (30 sec intervals)
        var currentTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds() / timeStep;

        // Convert the time into a byte array
        var timeBytes = BitConverter.GetBytes(currentTime);
        Array.Reverse(timeBytes);  // Ensure big-endian byte order

        // Decode the base32-encoded secret key
        var keyBytes = Code32.Decode(secretKey);

        // Generate HMAC-SHA1 hash using the secret key and the time
        using (var hmac = new HMACSHA1(keyBytes))
        {
            var hash = hmac.ComputeHash(timeBytes);

            // Use dynamic truncation to extract a 6-digit OTP
            int offset = hash[hash.Length - 1] & 0x0F;
            int binaryCode = (hash[offset] & 0x7F) << 24
                           | (hash[offset + 1] & 0xFF) << 16
                           | (hash[offset + 2] & 0xFF) << 8
                           | (hash[offset + 3] & 0xFF);

            // Generate the OTP (mod 10^digits)
            int otp = binaryCode % (int)Math.Pow(10, digits);

            // Return the OTP as a zero-padded string
            return otp.ToString(new string('0', digits));
        }

    }
    public static byte[] GenerateRandomKey(int length)
    {
        byte[] key = new byte[length];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(key); // Vult de array met veilige willekeurige bytes
        }
        return key;
    }
}
