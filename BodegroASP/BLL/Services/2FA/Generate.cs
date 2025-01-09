namespace Twofactor;
using System.Security.Cryptography;
public class Generate
{
    // This method generates a TOTP code based on the current time
    public static string OTP(string secretKey, DateTime dateTime, int digits = 6, int timeStep = 30)
    {
        // Normalize input timestamp (no milliseconds)
        dateTime = dateTime.AddTicks(-(dateTime.Ticks % TimeSpan.TicksPerSecond));

        // Convert normalized time to Unix timestamp and divide by timeStep
        long currentTime = (long)(new DateTimeOffset(dateTime).ToUnixTimeSeconds() / timeStep);

        // Convert timestamp into a byte array (big-endian)
        byte[] timeBytes = BitConverter.GetBytes(currentTime);
        if (BitConverter.IsLittleEndian)
        {
            Array.Reverse(timeBytes); // Ensure big-endian order
        }

        // Decode the secret key from Base32
        byte[] keyBytes = Code32.Decode(secretKey);

        // Generate HMAC-SHA1 hash using the key and the timeBytes
        using (var hmac = new HMACSHA1(keyBytes))
        {
            byte[] hash = hmac.ComputeHash(timeBytes);

            // Use dynamic truncation to extract a 6-digit OTP
            int offset = hash[hash.Length - 1] & 0x0F;
            int binaryCode = (hash[offset] & 0x7F) << 24
                           | (hash[offset + 1] & 0xFF) << 16
                           | (hash[offset + 2] & 0xFF) << 8
                           | (hash[offset + 3] & 0xFF);

            // Compute the OTP as binaryCode mod 10^digits
            int otp = binaryCode % (int)Math.Pow(10, digits);

            // Return the OTP as a zero-padded string
            return otp.ToString(new string('0', digits));
        }
    }

    public static byte[] RandomKey(int length)
    {
        byte[] key = new byte[length];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(key); // Vult de array met veilige willekeurige bytes
        }
        return key;
    }
}
