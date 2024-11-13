using System;

namespace CsharpConsoleBankingApplication
{
    // Represents a single transaction within a bank account.
    public class Transaction
    {
        // Unique identifier for the transaction.
        public string TransactionID { get; private set; }

        // Type of transaction (e.g., Deposit, Withdrawal, Interest).
        public string Type { get; private set; }

        // Amount involved in the transaction.
        public decimal Amount { get; private set; }

        // Date and time when the transaction occurred.
        public DateTime Date { get; private set; }

        // Initializes a new transaction with the specified type and amount.
        public Transaction(string type, decimal amount)
        {
            TransactionID = GenerateTransactionID();
            Type = type;
            Amount = amount;
            Date = DateTime.Now;
        }

        // Generates a unique transaction ID using a GUID.
        private string GenerateTransactionID()
        {
            return Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
        }
    }
}
