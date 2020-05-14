using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount
{
    //The bank account class needs to accept deposits and withdrawals
    //Let's implement deposits and withdrawals by creating a journal of every transaction for the account
    //updating the balance on each transaction
    //The history can be used to audit all transactions and manage daily balances
    //By computing the balance from the history of all transactions when needed,
    //any errors in a single transaction that are fixed will be correctly reflected in the balance on the next computation.
    class Transaction
    {
        public decimal Amount { get; }
        public DateTime Date { get; }
        public string Notes { get; }

        public Transaction(decimal amount, DateTime date, string note)
        {
            this.Amount = amount;
            this.Date = date;
            this.Notes = note;
        }
    }
}
