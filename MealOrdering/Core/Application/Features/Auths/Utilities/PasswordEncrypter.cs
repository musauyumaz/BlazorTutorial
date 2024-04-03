using System.Text;

namespace Application.Features.Auths.Utilities
{
    public class PasswordEncrypter
    {
        public static string Encrypt(string password)
        {
            byte[]? plainTextBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}



