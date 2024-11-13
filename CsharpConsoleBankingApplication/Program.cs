using System;
using System.Collections.Generic;

namespace CsharpConsoleBankingApplication
{
    // The main program class that handles user interactions and application flow.
    public class Program
    {
        // The entry point of the application. Displays the main menu and handles user input.
        public static void Main(string[] args)
        {
            // Dictionary to store all registered users with username as the key.
            Dictionary<string, User> users = new Dictionary<string, User>(StringComparer.OrdinalIgnoreCase);
            bool isRunning = true; // Flag to control the main loop.

            Console.WriteLine("======================================");
            Console.WriteLine("Welcome to the C# Console Banking App!");
            Console.WriteLine("======================================\n");

            while (isRunning)
            {
                Console.WriteLine("Main Menu:");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        RegisterUser(users);
                        break;
                    case "2":
                        LoginUser(users);
                        break;
                    case "3":
                        isRunning = false;
                        Console.WriteLine("Thank you for using the Banking App. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.\n");
                        break;
                }
            }
        }

        // Handles the registration process by collecting username and password.
        private static void RegisterUser(Dictionary<string, User> users)
        {
            try
            {
                Console.Write("Enter a username (5-15 characters): ");
                string username = Console.ReadLine();

                Console.Write("Enter a password (8-20 characters): ");
                string password = Console.ReadLine();

                // Check if the username already exists (case-insensitive).
                if (users.ContainsKey(username))
                {
                    Console.WriteLine("Username already exists. Please choose a different username.\n");
                    return;
                }

                // Create a new user and add to the users dictionary.
                User newUser = new User(username, password);
                users.Add(username, newUser);
                Console.WriteLine("Registration successful!\n");
            }
            catch (ArgumentException ex)
            {
                // Display validation errors.
                Console.WriteLine($"Registration failed: {ex.Message}\n");
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors.
                Console.WriteLine($"An unexpected error occurred: {ex.Message}\n");
            }
        }

        // Handles the login process by verifying username and password.
        private static void LoginUser(Dictionary<string, User> users)
        {
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            // Check if the user exists and the password is correct.
            if (users.TryGetValue(username, out User user) && user.CheckPassword(password))
            {
                Console.WriteLine("\nLogin successful!\n");
                UserMenu(user);
            }
            else
            {
                Console.WriteLine("\nInvalid username or password.\n");
            }
        }

        // Displays the user-specific menu after successful login and handles user actions.
        private static void UserMenu(User user)
        {
            bool userLoggedIn = true; // Flag to control the user menu loop.

            while (userLoggedIn)
            {
                Console.WriteLine("User Menu:");
                Console.WriteLine("1. Open Account");
                Console.WriteLine("2. View Accounts");
                Console.WriteLine("3. Deposit");
                Console.WriteLine("4. Withdraw");
                Console.WriteLine("5. Check Balance");
                Console.WriteLine("6. View Statement");
                Console.WriteLine("7. Apply Monthly Interest");
                Console.WriteLine("8. Logout");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            OpenAccount(user);
                            break;
                        case "2":
                            user.DisplayAccounts();
                            break;
                        case "3":
                            PerformDeposit(user);
                            break;
                        case "4":
                            PerformWithdrawal(user);
                            break;
                        case "5":
                            CheckBalance(user);
                            break;
                        case "6":
                            ViewStatement(user);
                            break;
                        case "7":
                            ApplyInterest(user);
                            break;
                        case "8":
                            userLoggedIn = false;
                            Console.WriteLine("Logged out successfully.\n");
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.\n");
                            break;
                    }
                }
                catch (FormatException)
                {
                    // Handle cases where input is not in the expected format.
                    Console.WriteLine("Invalid input format. Please enter the correct data type.\n");
                }
                catch (Exception ex)
                {
                    // Handle any unexpected errors.
                    Console.WriteLine($"An error occurred: {ex.Message}\n");
                }
            }
        }

        // Handles the process of opening a new bank account for the user.
        private static void OpenAccount(User user)
        {
            try
            {
                Console.Write("Enter account holder name: ");
                string accountHolder = Console.ReadLine();

                string accountType;
                while (true)
                {
                    Console.Write("Enter account type (savings/checking): ");
                    accountType = Console.ReadLine().ToLower();
                    if (accountType == "savings" || accountType == "checking")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid account type. Please enter 'savings' or 'checking'.");
                    }
                }

                decimal initialDeposit;
                while (true)
                {
                    Console.Write("Enter initial deposit amount: ");
                    string depositInput = Console.ReadLine();
                    if (decimal.TryParse(depositInput, out initialDeposit) && initialDeposit >= 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid amount. Please enter a positive number.");
                    }
                }

                // Create the new account.
                user.CreateAccount(accountHolder, accountType, initialDeposit);
                Console.WriteLine();
            }
            catch (ArgumentException ex)
            {
                // Display validation errors.
                Console.WriteLine($"Account creation failed: {ex.Message}\n");
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors.
                Console.WriteLine($"An unexpected error occurred: {ex.Message}\n");
            }
        }

        // Handles deposit transactions by collecting account number and deposit amount.
        private static void PerformDeposit(User user)
        {
            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();
            Account account = user.GetAccount(accountNumber);

            if (account != null)
            {
                decimal amount;
                while (true)
                {
                    Console.Write("Enter deposit amount: ");
                    string amountInput = Console.ReadLine();
                    if (decimal.TryParse(amountInput, out amount) && amount > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid amount. Please enter a positive number.");
                    }
                }

                account.Deposit(amount);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Account not found.\n");
            }
        }

        // Handles withdrawal transactions by collecting account number and withdrawal amount.
        private static void PerformWithdrawal(User user)
        {
            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();
            Account account = user.GetAccount(accountNumber);

            if (account != null)
            {
                decimal amount;
                while (true)
                {
                    Console.Write("Enter withdrawal amount: ");
                    string amountInput = Console.ReadLine();
                    if (decimal.TryParse(amountInput, out amount) && amount > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid amount. Please enter a positive number.");
                    }
                }

                account.Withdraw(amount);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Account not found.\n");
            }
        }

        // Handles balance checking by collecting the account number and displaying the balance.
        private static void CheckBalance(User user)
        {
            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();
            Account account = user.GetAccount(accountNumber);

            if (account != null)
            {
                account.DisplayBalance();
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Account not found.\n");
            }
        }

        // Handles viewing the account statement by collecting the account number.
        private static void ViewStatement(User user)
        {
            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();
            Account account = user.GetAccount(accountNumber);

            if (account != null)
            {
                account.DisplayStatement();
            }
            else
            {
                Console.WriteLine("Account not found.\n");
            }
        }

        // Handles applying monthly interest to the specified account.
        private static void ApplyInterest(User user)
        {
            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();
            Account account = user.GetAccount(accountNumber);

            if (account != null)
            {
                account.ApplyMonthlyInterest();
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Account not found.\n");
            }
        }
    }
}
