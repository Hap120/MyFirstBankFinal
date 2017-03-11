using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstBank
{
    public enum AccountTypes
    {
        Checking,
        Savings
    }
        public class Account
        {
            #region Statics
            private static int lastAccountNumber = 0;

            #endregion

            #region Properties
            [Key]
            public int AccountNumber { get; private set; }

            public string AccountName { get; set; }

            public string EmailAddress { get; set; }

            public decimal Balance { get; private set; }

        public AccountTypes TypeOfAccount { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
        #endregion

        #region Methods

        //constructor
        public Account() : this("", 0.0M)
            {
                // this.AccountNumber = ++lastAccountNumber;
            }

            public Account(string emailAddress) : this(emailAddress, 0.0M)
            {
                //   this.AccountNumber = ++lastAccountNumber;
                //  this.EmailAddress = emailAddress;
            }

            public Account(string emailAddress, decimal balance)
            {
                this.AccountNumber = ++lastAccountNumber;
                this.EmailAddress = emailAddress;
                this.Balance = balance;

            }

            
            public decimal Deposit(decimal amount)
            {
                // Balance= Balance + amount;
                Balance += amount;
                return Balance;
            }

            public void Withdraw(decimal amount)
            {
                Balance -= amount;
            }


            #endregion

        }
    }


