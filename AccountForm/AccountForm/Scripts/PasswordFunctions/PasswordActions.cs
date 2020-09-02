using System;
using System.Security.Cryptography;

namespace AccountForm.Scripts.PasswordFunctions
{
    /// <summary>
    /// Class used to generate the password hash and salt
    /// </summary>
    public static class PasswordActions
    {
        /// <summary>
        /// This function salts the pass
        /// </summary>
        /// <returns></returns>
        public static string GenerateSalt()
        {
            var rng = new RNGCryptoServiceProvider();
            var buff = new byte[128 / 8];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }
    }
}
