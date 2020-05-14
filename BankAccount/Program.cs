using System;
using System.Collections.Generic;

namespace BankAccount
{
    class Program
    {
        public class BankAccount
        {
            //The list of the transactions
            private List<Transaction> allTransactions = new List<Transaction>();
            //It is used to initialize the account number
            private static  int accountNumberSeed = 1234567890;
            // a 10-digit number that uniquely identifies the bank account.
            public string Number { get; }
            //a string that stores the name or names of the owners.
            public string Owner { get; set; }
            //The balance can be retrieved.  The initial balance must be positive.
            //summing the values of all transactions
            public decimal Balance 
            {
                get
                {
                    decimal balance = 0;
                    foreach (var item in allTransactions)
                    {
                        balance += item.Amount;
                    }

                    return balance;
                }
                set { this.Balance = value; }
            }

            public BankAccount(string name, decimal initialBalance)
            {
                this.Number = accountNumberSeed.ToString();
                //accountNumberSeed++;

                this.Owner = name;
                MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
            }

            //The bank account accepts deposits.
            public void MakeDeposit(decimal amount, DateTime date, string note)
            {
                if (amount <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
                }
                var deposit = new Transaction(amount, date, note);
                allTransactions.Add(deposit);
            }

            //The bank account accepts withdrawals.
            //any withdrawal must not create a negative balance
            public void MakeWithdrawal(decimal amount, DateTime date, string note)
            {
                if (amount <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
                }
                if (Balance - amount < 0)
                {
                    throw new InvalidOperationException("Not sufficient funds for this withdrawal");
                }
                var withdrawal = new Transaction(-amount, date, note);
                allTransactions.Add(withdrawal);
            }
        }

        static void Main(string[] args)
        {
            var account = new BankAccount("Saker", 1000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");
            account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
            Console.WriteLine(account.Balance);
            account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
            Console.WriteLine(account.Balance);
        }
    }
}
