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
                Console.WriteLine("5. Print all transacations");
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
                        try
                        {
                            PrintAllAccounts(emailAddress);
                            Console.Write("Select an accountnumber: ");
                            var accountNum2 = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter an amount to deposit: ");
                            var amount2 = Convert.ToDecimal(Console.ReadLine());
                            Bank.Deposit(accountNum2, amount2);
                        }
                        catch(FormatException)
                        {
                            Console.WriteLine("Invalid value");
                        }
                        catch (ArgumentOutOfRangeException ox)
                        {
                            Console.WriteLine(ox.Message + "Please try again");
                        }
                        catch (ArgumentException ax)
                        {
                            Console.WriteLine(ax.Message + "Please try again");
                        }
                        
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.Message);
                        }
                        break;
                        case "3":
                        PrintAllAccounts(emailAddress);
                        Console.Write("Select an accountnumber: ");
                        var accountNum = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter an amount to deposit: ");
                        var amount = Convert.ToDecimal(Console.ReadLine());

                        Bank.Withdraw(accountNum, amount);
                        break;
                       case "4":
                        PrintAllAccounts(emailAddress);
                         break;
                       case "5":
                        PrintAllAccounts(emailAddress);
                        Console.Write("Select an accountnumber: ");
                        accountNum = Convert.ToInt32(Console.ReadLine());
                        var transactions = Bank.GetAllTransactions(accountNum);
                        foreach (var transaction in transactions)
                        {
                            Console.WriteLine($"Id: {transaction.TransactionNumber}, Description: {transaction.Description}, Type: {transaction.TypeOfTransaction}, Amount: {transaction.Amount}, Date: {transaction.TransactionDate}");
                        }
                        break;
                       default:
                            Console.WriteLine("Sorry option not available");
                            break;
                    }
                }

            }

        static void PrintAllAccounts(string emailAddress)
        {
            var accounts = Bank.GetAllAccounts(emailAddress);

            foreach (var account in accounts)
            {
                Console.WriteLine($"Account number: {account.AccountNumber}, Balance: {account.Balance:C}");
            }
        }

        
        }
    }

    

