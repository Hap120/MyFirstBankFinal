using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstBank
{     // if a class is staic every methiod, property should be static
    public static class Bank //pascal case .. first letter of every word is up case as oppsed to camel case
    {
        //something that does not need to be seen is a variable as opposed to a property



        public static string Name { get; set; }

        public static Account CreateAccount(string accountName, string emailAdddress, decimal amount, AccountTypes typeOfAccount)
        {

            var db = new BankModel();
            var account = new Account(emailAdddress, amount);
            account.TypeOfAccount = typeOfAccount;
            account.AccountName = accountName;
            db.Accounts.Add(account);
            db.SaveChanges();
            return account;
        }

        /// <summary>
        /// Deposit Money into your account
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <param name="amount"></param>
        /// <exception cref="ArgumentException">Argument exception</exception>
        public static void Deposit(int accountNumber, decimal amount)
        {
            if (accountNumber <= 0)
            {
                throw new ArgumentException("Account Number is invalid");

            }
            if (amount <= 0)
            {
                throw new ArgumentException("Amount is invalid");
            }

            var db = new BankModel();
            var account = db.Accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
            if (account == null)
            {
                throw new ArgumentOutOfRangeException("Invalid AccountNumber");
            }
            account.Deposit(amount);
            db.Entry(account).State = System.Data.Entity.EntityState.Modified;

            var transaction = new Transaction();
            transaction.TransactionDate = DateTime.Now;
            transaction.Amount = amount;
            transaction.TypeOfTransaction = TransactionType.Credit;
            transaction.Description = "Deposit to the account";
            transaction.AccountNumber = accountNumber;

            db.Transactions.Add(transaction);
            db.SaveChanges();
        }


        public static void Withdraw(int accountNumber, decimal amount)
        {
            var db = new BankModel();
            var account = db.Accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
            if (account != null)
            {
                account.Withdraw(amount);
                db.Entry(account).State = System.Data.Entity.EntityState.Modified;

                var transaction = new Transaction();
                transaction.TransactionDate = DateTime.Now;
                transaction.Amount = amount;
                transaction.TypeOfTransaction = TransactionType.Debit;
                transaction.Description = "Withdraw from the account";
                transaction.AccountNumber = accountNumber;

                db.Transactions.Add(transaction);
                db.SaveChanges();
            }
        }

        public static IQueryable<Account> GetAllAccounts(string emailAddress)
        {
            //a is jsut a variable and can be called whatever you want
            var db = new BankModel();
            return db.Accounts.Where(a => a.EmailAddress == emailAddress);


            /*  foreach (var account in db.Accounts.Where(a => a.EmailAddress == emailAddress))
              {

                  Console.WriteLine($"Account number: {account.AccountNumber}, Balance: {account.Balance:C}");
              }
              */
        }

        public static IQueryable<Transaction> GetAllTransactions(int accountNumber)
        {
            var db = new BankModel();
            return db.Transactions.Where(t => t.AccountNumber == accountNumber).OrderByDescending(t => t.TransactionDate);
        }
    }
 }

