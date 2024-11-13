# C# Console Banking Application

Welcome to the C# Console Banking Application! This project is a simple console-based application to simulate basic banking functions, such as user registration, account management, transaction processing, and more.

## About

This application is designed to help users manage bank accounts through a command-line interface. It covers essential banking functions, allowing users to create accounts, deposit/withdraw funds, view balances, and more.

## Features

1. **User Registration & Login**  
   Users can create accounts with a unique username and password. Login verification ensures only registered users can access their bank accounts.

2. **Account Management**  
   Registered users can open new bank accounts, choose between savings and checking account types, and set an initial deposit.

3. **Transaction Processing**  
   Users can deposit and withdraw funds from their accounts, with validation to prevent overdrafts.

4. **Statement Generation**  
   A transaction history feature shows all past deposits and withdrawals.

5. **Interest Calculation**  
   Monthly interest is applied automatically to savings accounts.

6. **Balance Check**  
   Users can view the current balance of their accounts at any time.

## Requirements

- .NET SDK (latest version recommended)
- C# compatible editor (Visual Studio, VS Code, etc.)

## Setup and Installation

1. **Clone the Repository**  
   ```bash
   git clone https://github.com/yourusername/CsharpConsoleBankingApplication.git
   ```
2. **Navigate to the Project Directory**
   ```bash
   cd CsharpConsoleBankingApplication
   ```
3. **Build and Run the Application**
   ```bash
   dotnet build
   dotnet run
   ```


## Usage

### Main Menu Options
- **Register**: Create a new user account.
- **Login**: Access the banking features for registered users.
- **Exit**: Exit the application.

### User Menu Options (after login)
- **Open Account**: Create a new bank account (savings/checking).
- **View Accounts**: List all accounts for the logged-in user.
- **Deposit**: Add funds to an account.
- **Withdraw**: Remove funds from an account.
- **Check Balance**: View current account balance.
- **View Statement**: Display account transaction history.
- **Apply Monthly Interest**: Calculate and apply interest for savings accounts.
- **Logout**: Exit the user menu and return to the main menu.


## Example Usage

Upon running the application, the following sequence demonstrates typical user actions:

```plaintext
======================================
Welcome to the C# Console Banking App!
======================================

Main Menu:
1. Register
2. Login
3. Exit
Select an option: 1

Enter a username (5-15 characters): user123
Enter a password (8-20 characters): password123

Registration successful!

Main Menu:
1. Register
2. Login
3. Exit
Select an option: 2

Enter your username: user123
Enter your password: password123

Login successful!

User Menu:
1. Open Account
2. View Accounts
```


## Acknowledgments

This project is developed as a practice assignment to enhance skills in C# and console applications, with functionality inspired by typical banking requirements.
