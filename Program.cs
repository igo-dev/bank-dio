using System;
using System.Collections.Generic;
using System.Threading;
using bank_dio.Models;

namespace bank_dio
{
    class Program
    {
        static List<AccountModel> accountList = new();
        static void Main(string[] args)
        {
            
            string[] options = {
                "1 - List Accounts",
                "2 - Create new account",
                "3 - Transfer",
                "4 - Withdraw",
                "5 - Deposit",
                "X - Exit"
                };

            displayOptions:

            Console.WriteLine("\n\nWelcome to the DIO Bank.\nChoose one option below:\n");
            foreach (string s in options)
            {
                Console.WriteLine(s);
            }
                Console.WriteLine();
            switch (Console.ReadKey().Key)
            {
                
                case ConsoleKey.D1:
                ListAccounts();
                break;

                case ConsoleKey.D2:
                Console.Clear();
                CreateAccount();
                break;

                case ConsoleKey.D3:
                Transfer();
                break;

                case ConsoleKey.D4:
                Withdraw();
                break;

                case ConsoleKey.D5:
                Deposit();
                break;

                case ConsoleKey.X: // When X pressed do cool stuff and close.
                Console.SetCursorPosition(2,14);
                Console.WriteLine("Closing connections.../");
                Thread.Sleep(300);
                Console.SetCursorPosition(2,14);
                Console.WriteLine("Closing connections...-");
                Thread.Sleep(300);
                Console.SetCursorPosition(2,14);
                Console.WriteLine(@"Closing connections...\");
                Thread.Sleep(300);
                Console.SetCursorPosition(2,14);
                Console.WriteLine("Shutting servers down...-");
                Thread.Sleep(300);
                Console.SetCursorPosition(2,14);
                Console.WriteLine("Shutting servers down.../");
                Thread.Sleep(300);
                Environment.Exit(0);
                break;
            }
            goto displayOptions;

        }

        private static void Deposit()
        {
            Console.WriteLine("\n\nInsert account number:");
            int accountIndex = int.Parse(Console.ReadLine());
            Console.WriteLine("\n\nInsert value to deposit:");
            double depositValue = double.Parse(Console.ReadLine());

            accountList[accountIndex].Deposit(depositValue);
        }

        private static void Withdraw()
        {
            Console.WriteLine("\n\nInsert account number:");
            int accountIndex = int.Parse(Console.ReadLine());
            Console.WriteLine("\nInsert value to withdraw:");
            double withdrawValue = double.Parse(Console.ReadLine());

            accountList[accountIndex].Withdraw(withdrawValue);
        }

        private static void Transfer()
        {
            Console.WriteLine("\n\nAccount number to transfer from:");
            int fromAccountIndex = int.Parse(Console.ReadLine());
            Console.WriteLine("\nAccount number to transfer to:");
            int toAccountIndex = int.Parse(Console.ReadLine());

            Console.WriteLine("\nAmount to be transfered:");
            double transferenceValue = double.Parse(Console.ReadLine());

            accountList[fromAccountIndex].Transfer(transferenceValue, accountList[toAccountIndex]);
        }

        private static void CreateAccount()
        {
            Console.WriteLine("\n\nCreate new account");

            Console.WriteLine("Account type: [ 0 ] Personal or [ 1 ] Corporate");
            int accountType = int.Parse(Console.ReadLine());

            Console.WriteLine("Your name:");
            string name = Console.ReadLine();

            Console.WriteLine("Desired initial balance:");
            int balance = int.Parse(Console.ReadLine());

            Console.WriteLine("Desired initial credit:");
            int credit = int.Parse(Console.ReadLine());

            AccountModel newAccount = new((AccountTypeModel)accountType,
                                                            name,
                                                            balance,
                                                            credit);

            accountList.Add(newAccount);
        }

        private static void ListAccounts()
        {
            Console.WriteLine("\n\nList Accounts");

            if (accountList.Count == 0)
            {
            Console.WriteLine("No accounts found.");
            return;
            }
            
            for (int i = 0; i < accountList.Count; i++)
            {
                AccountModel account = accountList[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(account);
            }
        }
    }
}
