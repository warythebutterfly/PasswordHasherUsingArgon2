using Konscious.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordHasherUsingArgon2
{
    public static class PasswordHasher
    {
        public static string Create(string password, string salt)
        {
            try
            {
                var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));

                argon2.Salt = Encoding.UTF8.GetBytes(salt);
                argon2.DegreeOfParallelism = 8; // four cores
                argon2.Iterations = 10;
                argon2.MemorySize = 1024 * 1024; // 1 GB

                var hash = Convert.ToBase64String(argon2.GetBytes(24));
                Console.WriteLine("indomie");

                return hash;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            
        }


        //public static bool Validate(string password, byte[] salt, string hash)
        //{
        //    var value = new Argon2id(Encoding.UTF8.GetBytes(password));
        //    return Create(value, salt) == hash;
        //}
    }
}
