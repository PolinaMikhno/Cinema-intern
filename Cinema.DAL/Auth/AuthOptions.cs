using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Cinema.DAL.Auth
{
    // ауф
    public static class AuthOptions
    {
        public const string Issuer = "Issuer";
        public const string Audience = "Audience";
        private const string Key = "1234567890qwertyuiopasdfghjkl";
        public const int Lifetime = 50000;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
    }
}