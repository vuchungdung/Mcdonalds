using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace API.Helper
{
    public static class PasswordSecurity
    {
        private const string Alg = "HmacSHA256";

        private const string Salt = "rz8LuOtFBXphj9WQfvFh";

        public static string GetHashedPassword(string password)
        {
            string _key = string.Join(":", password, Salt);

            using (HMAC hmac = HMAC.Create(Alg))
            {
                hmac.Key = Encoding.UTF8.GetBytes(Salt);
                hmac.ComputeHash(Encoding.UTF8.GetBytes(_key));

                StringBuilder _builder = new StringBuilder();
                foreach (byte num in hmac.Hash)
                {
                    _builder.AppendFormat("{0:X2}", num);
                }

                var _convertBuilder = Encoding.UTF8.GetBytes(_builder.ToString());

                return Convert.ToBase64String(_convertBuilder);
            }
        }
    }
}
