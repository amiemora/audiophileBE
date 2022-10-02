using System.Security.Cryptography;
using System.Text;

namespace AudiophileBE.Tools
{
    public class Password
    {
        public static string HashPassword(string password)
        {
            var sha = SHA256.Create();
            var asByteArray = Encoding.Default.GetBytes(password);
            var hashPassword = sha.ComputeHash(asByteArray);
            return Convert.ToBase64String(hashPassword);
        }
    }
}
