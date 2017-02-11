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

        public static Account CreateAccount(string emailAdddress, decimal amount)
        {
            var db = new BankModel();
            var account = new Account(emailAdddress, amount);
            db.Accounts.Add(account);
            db.SaveChanges();
            return account;
        }

        public static void PrintAllAccounts(string emailAddress)
        {
            //a is jsut a variable and can be called whatever you want
            var db = new BankModel();
            foreach (var account in db.Accounts.Where(a => a.EmailAddress == emailAddress))
            {
                Console.WriteLine($"Account number: {account.AccountNumber}, Balance: {account.Balance:C}");
            }
        }
    }
}
