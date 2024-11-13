using System;
using System.Collections.Generic;

namespace CsharpConsoleBankingApplication
{
    // Represents a user in the banking system, holding multiple bank accounts.
    public class User
    {
        // Unique username for the user.
        public string Username { get; private set; }

        // Password for the user (stored in plain text for simplicity; consider hashing for real applications).
        private string Password;

        // Dictionary to store accounts owned by the user with account number as the key.
        private Dictionary<string, Account> Accounts;

        // Initializes a new user with the specified username and password.
        public User(string username, string password)
        {
            ValidateUsername(username);
            ValidatePassword(password);

            Username = username;
            Password = password;
            Accounts = new Dictionary<string, Account>();
        }

        // Validates the provided password against the user's password.
        public bool CheckPassword(string inputPassword)
        {
            return Password == inputPassword;
        }

        // Creates a new bank account for the user.
        public void CreateAccount(string accountHolder, string accountType, decimal initialDeposit)
        {
            Account newAccount = new Account(accountHolder, accountType, initialDeposit);
            Accounts.Add(newAccount.AccountNumber, newAccount);
            Console.WriteLine($"Account {newAccount.AccountNumber} created successfully.");
        }

        // Retrieves an account based on the provided account number.
        public Account GetAccount(string accountNumber)
        {
            Accounts.TryGetValue(accountNumber, out Account account);
            return account;
        }

        // Displays all accounts associated with the user.
        public void DisplayAccounts()
        {
            if (Accounts.Count == 0)
            {
                Console.WriteLine("No accounts available.");
                return;
            }

            Console.WriteLine("\nYour Accounts:");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Account Number\tType\t\tBalance");
            Console.WriteLine("--------------------------------------------------");
            foreach (var account in Accounts.Values)
            {
                string formattedType = char.ToUpper(account.AccountType[0]) + account.AccountType.Substring(1);
                Console.WriteLine($"{account.AccountNumber}\t{formattedType}\t\t{account.Balance:C}");
            }
            Console.WriteLine("--------------------------------------------------\n");
        }

        // Validates the username to ensure it meets length requirements.
        private void ValidateUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Username cannot be empty.");
            }

            if (username.Length < 5 || username.Length > 15)
            {
                throw new ArgumentException("Username must be between 5 and 15 characters.");
            }
        }

        // Validates the password to ensure it meets length requirements.
        public void ValidatePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password cannot be empty.");
            }

            if (password.Length < 8 || password.Length > 20)
            {
                throw new ArgumentException("Password must be between 8 and 20 characters.");
            }
        }
    }
}
