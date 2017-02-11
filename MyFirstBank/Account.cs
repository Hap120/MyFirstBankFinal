using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstBank
{
        public class Account
        {
            #region Statics
            private static int lastAccountNumber = 0;

            #endregion

            #region Properties
            public int AccountNumber { get; private set; }

            public string EmailAddress { get; set; }

            public decimal Balance { get; private set; }

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


