using Konscious.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
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
                argon2.MemorySize = 32768; 
               

                var hash = Convert.ToBase64String(argon2.GetBytes(16));
                
                return hash;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            
        }

        //to validate the hash, you can use any of these methods
        public static bool Validate(string password, string saltCreated, string hashCreated)
        {
            return Create(password, saltCreated) == hashCreated;
        }

        public static bool VerifyHash(string password, string saltCreated, string hashCreated)
        {
            var newHash = Create(password, saltCreated);
            return hashCreated.SequenceEqual(newHash);
        }
    }
}
