using System.Security.Cryptography;
using System.Text;

namespace ContactsAPI.Helpers
{
    public class Helper
    {
        private static string ToHex(byte[] bytes, bool upperCase)
        {
            StringBuilder result = new StringBuilder(bytes.Length * 2);

            for (int i = 0; i < bytes.Length; i++)
                result.Append(bytes[i].ToString(upperCase ? "X2" : "x2"));

            return result.ToString();
        }

        public static string PasswordHash(string password)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password);

            using (SHA256 sha256 = SHA256.Create())
            {
                bytes = sha256.ComputeHash(bytes);
            }

            return ToHex(bytes, true);
        }
    }
}
