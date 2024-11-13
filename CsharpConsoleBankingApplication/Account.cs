using System;
using System.Collections.Generic;

namespace CsharpConsoleBankingApplication
{
    // Represents a bank account with various operations like deposit, withdrawal, and interest application.
    public class Account
    {
        // Unique account number for the account.
        public string AccountNumber { get; private set; }

        // Name of the account holder.
        public string AccountHolder { get; private set; }

        // Type of the account (savings or checking).
        public string AccountType { get; private set; }

        // Current balance of the account.
        public decimal Balance { get; private set; }

        // List to store all transactions related to this account.
        private List<Transaction> Transactions;

        // Fixed interest rate for savings accounts.
        private const decimal InterestRate = 0.02m; // 2% interest rate

        // Keeps track of the last date when interest was applied.
        private DateTime LastInterestApplied;

        // Initializes a new account with the specified holder, type, and initial deposit.
        public Account(string accountHolder, string accountType, decimal initialDeposit)
        {
            if (initialDeposit < 0)
            {
                throw new ArgumentException("Initial deposit cannot be negative.");
            }

            AccountNumber = GenerateAccountNumber(); // Automatically generate a unique account number.
            AccountHolder = accountHolder;
            AccountType = accountType.ToLower();
            Balance = initialDeposit;
            Transactions = new List<Transaction>();
            LastInterestApplied = DateTime.Now;

            LogTransaction("Initial Deposit", initialDeposit); // Log the initial deposit as a transaction.
        }

        // Generates a unique 10-digit account number.
        private string GenerateAccountNumber()
        {
            Random random = new Random();
            // Generate a number between 0 and 999999999 and pad with leading zeros to make it 10 digits.
            return random.Next(0, 1000000000).ToString("D10");
        }

        // Allows depositing a specified amount into the account.
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Deposit amount must be positive.");
                return;
            }

            Balance += amount;
            LogTransaction("Deposit", amount);
            Console.WriteLine($"Successfully deposited {amount:C}. New balance: {Balance:C}");
        }

        // Allows withdrawing a specified amount from the account, ensuring sufficient balance.
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be positive.");
                return;
            }

            if (amount > Balance)
            {
                Console.WriteLine("Insufficient balance.");
                return;
            }

            Balance -= amount;
            LogTransaction("Withdrawal", amount);
            Console.WriteLine($"Successfully withdrew {amount:C}. New balance: {Balance:C}");
        }

        // Displays the current balance of the account.
        public void DisplayBalance()
        {
            Console.WriteLine($"Account Number: {AccountNumber}, Balance: {Balance:C}");
        }

        // Displays the transaction history of the account.
        public void DisplayStatement()
        {
            Console.WriteLine($"\nStatement for Account {AccountNumber}:");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("ID\tDate\t\t\tType\t\tAmount");
            Console.WriteLine("--------------------------------------------------");
            foreach (var transaction in Transactions)
            {
                Console.WriteLine($"{transaction.TransactionID}\t{transaction.Date.ToString("g")}\t{transaction.Type}\t\t{transaction.Amount:C}");
            }
            Console.WriteLine("--------------------------------------------------\n");
        }

        // Applies monthly interest to the account if it's a savings account and eligible.
        public void ApplyMonthlyInterest()
        {
            if (AccountType != "savings")
            {
                Console.WriteLine("Interest cannot be applied to checking accounts.");
                return;
            }

            DateTime now = DateTime.Now;
            // Check if at least one month has passed since the last interest application.
            if ((now.Year > LastInterestApplied.Year) ||
                (now.Year == LastInterestApplied.Year && now.Month > LastInterestApplied.Month))
            {
                decimal interest = Balance * InterestRate;
                Balance += interest;
                LogTransaction("Interest", interest);
                LastInterestApplied = now;
                Console.WriteLine($"Monthly interest of {interest:C} added. New balance: {Balance:C}");
            }
            else
            {
                Console.WriteLine("It's still not been one month since the last interest appplied.");
            }
        }

        // Logs a transaction by adding it to the transactions list.
        private void LogTransaction(string type, decimal amount)
        {
            Transactions.Add(new Transaction(type, amount));
        }
    }
}
