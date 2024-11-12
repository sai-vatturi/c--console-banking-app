using System;

namespace CsharpConsoleBankingApplication
{
    public class Account
    {
        public string AccountNumber { get; private set; }
        public decimal Balance { get; private set; }

        public Account(string accountNumber)
        {
            AccountNumber = accountNumber;
            Balance = 0.0m;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Deposit amount must be positive.");
                return;
            }
            Balance += amount;
            Console.WriteLine($"Successfully deposited {amount}. New balance: {Balance}");
        }

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
            Console.WriteLine($"Successfully withdrew {amount}. New balance: {Balance}");
        }

        public void DisplayBalance()
        {
            Console.WriteLine($"Account Number: {AccountNumber}, Balance: {Balance}");
        }
    }
}
