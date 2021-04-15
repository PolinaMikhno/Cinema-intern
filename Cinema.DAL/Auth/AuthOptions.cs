using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Cinema.DAL.Auth
{
    // ауф
    public class AuthOptions
    {
        public const string Issuer = "Issuer";
        public const string Audience = "Audience";
        private const string Key = "Key";
        public const int Lifetime = 1;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
    }
}