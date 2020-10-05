using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace PasswordHasherUsingArgon2
{
    public static class Salt
    {
        public static byte[] Create()
        {
            var buffer = new byte[128 / 8];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(buffer);
            return buffer;
        }
        public static byte[] CreateSalt()
        {
            var rng = new RNGCryptoServiceProvider();
            byte[] randomBytes = new byte[128 / 8];
            rng.GetBytes(randomBytes);
            RandomNumberGenerator generator = RandomNumberGenerator.Create();
            generator.GetBytes(randomBytes);
            return randomBytes;
        }
    }
}
