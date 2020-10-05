using System;

namespace PasswordHasherUsingArgon2
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");
            Console.Write("Enter your password: ");

            try
            {

                var value = Console.ReadLine();

                var salt = Convert.ToBase64String(Salt.CreateSalt());

                Console.WriteLine(salt);
                var saltCreated = salt;
                var hash = PasswordHasher.Create(value, salt);
                //Console.WriteLine($"Hash is '{ Convert.ToBase64String(hash) }'.");
                // Console.WriteLine($"Hash is "+Convert.ToBase64String(hash) +".");
                Console.WriteLine(hash);
                var hashCreated = hash;
                Console.WriteLine(hashCreated);
               

                Console.Write("Enter your password for validation: ");
                var password = Console.ReadLine();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
         
            //Console.WriteLine(saltCreated);

           


            //if (PasswordHasher.Validate(password, saltCreated, hashCreated) == true)
            //{
            //    Console.WriteLine("Password has been verified!");
            //    break;
            //}
            //else
            //{
            //    Console.WriteLine("Wrong password! Try again");
            //}

        }
    }
}
