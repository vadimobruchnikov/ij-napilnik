using System.Security.Cryptography;
using System.Text;

namespace Task04
{
    class CryptoLib
    {
        public static string HashBytesToString(byte[] hashBytes)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }

            return sb.ToString();
        }
        public static string CreateMD5(string input)
        {
            using MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            return HashBytesToString(hashBytes);
        }

        public static string CreateSHA1(string input)
        {
            using SHA1 sha1 = SHA1.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = sha1.ComputeHash(inputBytes);

            return HashBytesToString(hashBytes);
        }
    }
}
