using System;

namespace PasswordHasherUsingArgon2
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Console.WriteLine("Password Hashing Using Argon2");
                Console.Write("Enter your password: ");

                var value = Console.ReadLine();

                var salt = Convert.ToBase64String(Salt.CreateSalt());
                
                //OR

                //var salt = Convert.ToBase64String(Salt.Create());

                var saltCreated = salt;

                var hash = PasswordHasher.Create(value, salt);

                var hashCreated = hash;
               
                var isValid = true;

                while (isValid == true)
                {
                    Console.Write("Enter your password for validation: ");
                    var password = Console.ReadLine();

                    if (PasswordHasher.VerifyHash(password, saltCreated, hashCreated) == true)
                    {
                        Console.WriteLine("Password has been verified!");
                        break;
                    }

                    //  OR

                    //if (PasswordHasher.Validate(password, saltCreated, hashCreated) == true)
                    //{
                    //    Console.WriteLine("Password has been verified!");
                    //    break;
                    //}

                    else
                    {
                        Console.WriteLine("Wrong password! Try again");
                    }

                }

                Console.ReadLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

         

        }
    }
}
