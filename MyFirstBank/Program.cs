using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstBank
{
    class Program
    {
        static void Main(string[] args)
          {
                Console.WriteLine("**Welcome to my Bank**");
            Console.WriteLine("Please enter your email address");
            var emailAddress = Console.ReadLine();
            while (true)
                {
                    Console.WriteLine("0. Exit");
                    Console.WriteLine("1. Create an account");
                    Console.WriteLine("2. Deposit");
                    Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Print all accounts");
                    Console.WriteLine("Please select one of the options above");
                    var choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "0":
                            return;
                        case "1":
                        Console.WriteLine("Please enter your email address");
                        var emailAddress2 = Console.ReadLine();
                        var myAccount = Bank.CreateAccount(emailAddress, 0.0M);
                            Console.WriteLine($"The balance in my account - {myAccount.AccountNumber} is {myAccount.Balance:C} ");
                            break;
                        case "2":
                            break;
                        case "3":
                            break;
                       case "4":
                        Bank.PrintAllAccounts(emailAddress);
                         break;
                        default:
                            Console.WriteLine("Sorry option not available");
                            break;
                    }
                }

            }
        }
    }

    

