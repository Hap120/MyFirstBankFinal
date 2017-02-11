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
        private static List<Account> accounts = new List<Account>();


        public static string Name { get; set; }

        public static Account CreateAccount(string emailAdddress, decimal amount)
        {
            var account = new Account(emailAdddress, amount);
            accounts.Add(account);
            return account;
        }

        public static void PrintAllAccounts(string emailAddress)
        {
            //a is jsut a variable and can be called whatever you want
            foreach (var account in accounts.Where(a => a.EmailAddress == emailAddress))
            {
                Console.WriteLine($"Account number: {account.AccountNumber}, Balance: {account.Balance:C}");
            }
        }
    }
}
