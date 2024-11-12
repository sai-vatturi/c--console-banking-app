using System;
namespace CsharpConsoleBankingApplication
{
    public class UserNameValidationException : Exception
    {
        public UserNameValidationException(string message) :base(message)
        {
            Console.WriteLine(message);
        }
    }

    public class UserPasswordValidationException : Exception
    {
        public UserPasswordValidationException(string message) : base(message)
        {
            Console.WriteLine(message);
        }
    }

    public class Program
    {
        public static void Main(string[] args)

        {
            // create an array to store users
            List<User> users = new List<User>();

            // use a boolean to handle application running status
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("Welcome to C# Console Banking!");
                Console.WriteLine("==============================");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Exit");
                Console.Write("Select any value from 1 - 3: ");

                // Take user input
                string inp = Console.ReadLine();


                switch (inp)
                {
                    case "1":
                        Console.WriteLine("\nLogin to existing account:");
                        Console.WriteLine("----------------------------");

                        string username = Console.ReadLine();

                        break;
                    case "2":
                        Console.WriteLine("\nCreate new account:");
                        Console.WriteLine("-----------------------");

                        // Take input for username
                        bool UsernameAccepted = false;
                        string NewUserName = "";

                        while (!UsernameAccepted)
                        {
                            Console.Write("Enter username:");
                            NewUserName = Console.ReadLine();
                            try
                            {
                                ValidateUsername(NewUserName);
                                UsernameAccepted = true;

                            }
                            catch (UserNameValidationException uve)
                            {
                                Console.WriteLine("Invalid username: " + uve.Message);
                            }
                        }

                        // Take input for password
                        bool PasswordAccepted = false;
                        string NewPassword = "";

                        while (!PasswordAccepted)
                        {
                            Console.Write("Enter password:");
                            NewPassword = Console.ReadLine();
                            try
                            {
                                ValidateUsername(NewPassword);
                                PasswordAccepted = true;

                            }
                            catch (UserPasswordValidationException upve)
                            {
                                Console.WriteLine("Invalid password: " + upve.Message);
                            }
                        }

                        users.Add(new User(NewUserName, NewPassword));
                        Console.WriteLine("User successfully created! \n");
                        break;

                    case "3":
                        isRunning = false;
                        Console.WriteLine("\nExiting....");
                        break;
                    default:
                        Console.Write("Invalid Value. Select any value from 1 - 3: ");
                        break;
                }

            }
        }

        public static void ValidateUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new UserNameValidationException("Username cannot be empty!");
            }
            if (username.Length < 5)
            {
                throw new UserNameValidationException("Username must be 6 characters or more!");
            }
            if (username.Length > 15)
            {
                throw new UserNameValidationException("Username must be less than 15 charaters!");
            }
            if (!Char.IsLetter(username[0]))
            {
                throw new UserNameValidationException("Username must start with a letter!");
            }
        }

        public static void ValidatePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new UserPasswordValidationException("Password cannot be empty!");
            }
            if (password.Length < 8)
            {
                throw new UserPasswordValidationException("Password must be 8 characters or more!");
            }
            if (password.Length > 20)
            {
                throw new UserPasswordValidationException("Password must be less than 20 characters");
            }
        }
    }
}

