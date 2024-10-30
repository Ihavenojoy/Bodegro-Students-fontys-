using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bodegro2FALibrary
{
    public class Code32
    {
        private static readonly char[] _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567=".ToCharArray(); // Pading toegevoegd om invalids te voorkomen https://en.wikipedia.org/wiki/Base32#:~:text=Base%2032%20Encoding%20per%20%C2%A76,-The%20most%20widely&text=It%20uses%20an%20alphabet%20of%20A%E2%80%93Z%2C%20followed%20by%202,of%20the%20string%20modulo%208).
        public static string Encode(byte[] data)
        {

            int dataLength = data.Length;
            int charCount = (dataLength * 8 + 4) / 5; // 5 bits per Base32 character
            char[] result = new char[charCount];

            int buffer = data[0];
            int next = 1;
            int bitsLeft = 8;
            int charIndex = 0;

            while (charIndex < charCount)
            {
                if (bitsLeft < 5)
                {
                    if (next < dataLength)
                    {
                        buffer <<= 8;
                        buffer |= (data[next++] & 0xFF);
                        bitsLeft += 8;
                    }
                    else
                    {
                        int pad = 5 - bitsLeft;
                        buffer <<= pad;
                        bitsLeft += pad;
                    }
                }

                int index = (buffer >> (bitsLeft - 5)) & 0x1F;
                bitsLeft -= 5;
                result[charIndex++] = _alphabet[index];
            }

            return new string(result);
        }
        public static byte[] Decode(string base32)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567="; // Pading toegevoegd om invalids te voorkomen https://en.wikipedia.org/wiki/Base32#:~:text=Base%2032%20Encoding%20per%20%C2%A76,-The%20most%20widely&text=It%20uses%20an%20alphabet%20of%20A%E2%80%93Z%2C%20followed%20by%202,of%20the%20string%20modulo%208).
            base32 = base32.TrimEnd('=').ToUpper();

            // Controleer op geldige tekens
            foreach (char c in base32)
            {
                if (!alphabet.Contains(c))
                {
                    throw new ArgumentException($"Invalid Base32 character: {c}");
                }
            }

            byte[] output = new byte[base32.Length * 5 / 8];
            byte currentByte = 0;
            int bitsRemaining = 8;
            int mask = 0;
            int index = 0;

            foreach (char c in base32)
            {
                int value = alphabet.IndexOf(c);  // Zoek het teken op in het Base32-alfabet
                if (value < 0)
                {
                    throw new ArgumentException($"Invalid Base32 character: {c}");
                }

                if (bitsRemaining > 5)
                {
                    currentByte = (byte)(currentByte << 5 | value);
                    bitsRemaining -= 5;
                }
                else
                {
                    mask = value >> (5 - bitsRemaining);
                    currentByte = (byte)(currentByte << bitsRemaining | mask);
                    output[index++] = currentByte;
                    currentByte = (byte)(value & (31 >> bitsRemaining));
                    bitsRemaining += 3;
                }
            }
            return output;
        }
    }
}
