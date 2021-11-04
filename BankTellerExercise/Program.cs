using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankTellerExercise.Classes;

namespace BankTellerExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            bool leave = false;
            Console.WriteLine("Welcome to the virtual bank!");
            Console.WriteLine();
            Console.Write("What is your name?   ");
            string yourName = Console.ReadLine();

            var you = new BankCustomer
            {
                Name = yourName
            };


            Console.Write("Would you like a (C)urrent or a (S)avings account?:   ");
            var choice = Console.ReadLine();
            BankAccount yourAccount = new BankAccount();
            choice = choice.ToUpper();
            if (choice == "C")
            {
                Console.Write("What is the name of the current account?:  ");
                string name = Console.ReadLine().ToUpper();
                var newCheck = new CurrentAccount();

                you.AddAccount(newCheck, name);
            }
            else
            {
                Console.Write("What is the name of the savings account?:  ");
                string name = Console.ReadLine().ToUpper();

                var newSave = new SavingsAccount();

                you.AddAccount(newSave, name);
            }
            Console.Clear();

            while (!leave)
            {
                Console.WriteLine("Welcome to the bank "+yourName+"!");

                Console.WriteLine("______________________________________");
                Console.WriteLine();
                Console.WriteLine("What would you like to do today?");
                Console.WriteLine("1. Check your Balance");        //Check Balance
                Console.WriteLine("2. Withdraw money");        //Withdraw
                Console.WriteLine("3. Deposit money");        //Deposit
                Console.WriteLine("4. Transfer money to another account");        //Transfer
                Console.WriteLine("5. Open another account");
                Console.WriteLine("6. See a list of your accounts");    //List all of your accounts opened
                Console.WriteLine("7. Check VIP status");
                Console.WriteLine("8. Quit");        //Quit

                var menuChoice = decimal.Parse(Console.ReadLine());

                switch (menuChoice)
                {
                    case 1:
                        Console.Clear();

                        Console.Write("What is the name of the account would you like the balance of?   ");
                        Console.WriteLine();
                        string AChoice = Console.ReadLine();
                        foreach (var acct in you.Accounts)
                        {
                            if (acct.AccountNumber == AChoice.ToUpper())
                            {
                                Console.WriteLine($"Your balance in Account : {acct.AccountNumber} is  {acct.Balance.ToString("C2")}");
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.ReadLine();
                                Console.Clear();

                                break;
                            }
                        }
                        break;

                    case 2:
                        Console.Clear();

                        Console.WriteLine("Which account would you like to withdaraw from (Name on Account) ?   ");
                        string wAcct = Console.ReadLine().ToUpper();
                        for (int i = 0; i < you.Accounts.Length; i++)
                        {
                            if (you.Accounts[i].AccountNumber == wAcct)
                            {
                                Console.Write("How Much?   ");
                                decimal withdraw = decimal.Parse(Console.ReadLine());

                                if (you.Accounts[i] is SavingsAccount)
                                {
                                    if (withdraw > you.Accounts[i].Balance)
                                    {
                                        Console.Clear();
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.WriteLine("No.");
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.ReadLine();
                                        Console.Clear();
                                    }
                                }
                                else if (you.Accounts[i] is CurrentAccount)
                                {
                                    if (withdraw>you.Accounts[i].Balance)
                                    {
                                        Console.WriteLine("...If you insist...");
                                        Console.WriteLine();
                                        System.Threading.Thread.Sleep(2000);
                                        Console.WriteLine("You are now overdraft by $"+ Math.Abs(you.Accounts[i].Balance-withdraw));
                                        Console.ReadLine();
                                        Console.Clear();
                                    }
                                }
                                you.Accounts[i].Withdraw(withdraw);
                                Console.Clear();
                                break;
                            }

                            if (i == you.Accounts.Length - 1)
                            {
                                Console.WriteLine("You do not have that account...");
                            }
                        }
                        break;

                    case 3:

                        Console.Clear();
                        Console.WriteLine("Which account would you like to deposit to (Name on Account) ?   ");
                        string dAcct = Console.ReadLine().ToUpper();
                        for (int i = 0; i < you.Accounts.Length; i++)
                        {
                            if (you.Accounts[i].AccountNumber == dAcct)
                            {
                                Console.Write("How Much?   ");
                                decimal deposit = decimal.Parse(Console.ReadLine());
                                you.Accounts[i].Deposit(deposit);
                                Console.WriteLine($"{deposit.ToString("C2")} has been deposited to {you.Accounts[i].AccountNumber}.");
                                Console.ReadLine();
                                                               Console.Clear();
                                break;

                            }
                             if (i == you.Accounts.Length - 1)
                            {
                                Console.WriteLine("You do not have that account...");
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine();
                            }
                        }
                        break;


                    case 4:
                        Console.Clear();

                        bool doesNotExist = true;

                        while (doesNotExist)
                        {

                            Console.Write("Which account are you transferring from (Enter Name on account)?  ");
                           string tFrom = Console.ReadLine().ToUpper();
                            Console.Write("How Much?  ");
                            decimal transAmount = decimal.Parse(Console.ReadLine());
                            

                            for (int i = 0; i < you.Accounts.Length; i++)

                            {
                                if (i == you.Accounts.Length - 1 && you.Accounts[i].AccountNumber != tFrom)
                                {
                                    Console.WriteLine("That account doesnt't exist");
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    break;
                                }
                                else if (you.Accounts[i].AccountNumber == tFrom)
                                {
                                    var transferFrom = you.Accounts[i];
                                    while (doesNotExist)
                                    {

                                        Console.WriteLine();
                                        Console.Write("Which of your accounts are you transferring to (Enter Name on account)?   ");
                                        string tTo = Console.ReadLine().ToUpper();

                                        for (int a = 0; a < you.Accounts.Length; a++)
                                        {
                                            if (a == you.Accounts.Length - 1 && you.Accounts[a].AccountNumber != tTo)
                                            {
                                                Console.WriteLine("That account doesnt't exist");
                                                break;
                                            }
                                            else if (you.Accounts[a].AccountNumber == tTo)
                                            {
                                                var transferTo = you.Accounts[a];
                                                
                                                transferFrom.Transfer(transferTo, transAmount);

                                                Console.WriteLine($"Account: {transferTo.AccountNumber} has been transferred {transAmount.ToString("C2")}");
                                                Console.ReadLine();
                                                


                                                doesNotExist = false;
                                                Console.Clear();

                                                break;
                                            }
                                        }
                                    }

                                    break;
                                }
                            }
                        }
                                 
                        break;

                    case 5:
                        Console.Clear();

                        Console.WriteLine("What kind of account would you like to open? (C/S)  ");
                        string aChoice = Console.ReadLine().ToUpper();
                        if (aChoice == "C")
                        {
                            Console.Write("What is the name of the account?   ");
                            string aName = Console.ReadLine().ToUpper();
                            var newCheck = new CurrentAccount();
                          
                            you.AddAccount(newCheck, aName);
                            Console.WriteLine();

                            Console.WriteLine($"You have added account: {aName}.");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else
                        {
                            Console.Write("What is the name of the account?   ");
                            string aName = Console.ReadLine().ToUpper();
                            var newSave = new SavingsAccount();

                            you.AddAccount(newSave, aName);
                            Console.WriteLine();
                            Console.WriteLine($"You have added account: {aName}.");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.ReadLine();
                            Console.Clear();
                        }

                        break;


                    case 6:
                        //loop through each account in accounts and print the account name, type, and balance
                        Console.Clear();
                        Console.WriteLine("Generating List of Accounts");
                        Console.WriteLine("...");
                        Console.WriteLine("...");
                        Console.WriteLine("...");
                        System.Threading.Thread.Sleep(2000);
                        Console.WriteLine("{0,10}{1,20}{2,18}","Account Name","Type of Account","Balance");
                        foreach (var account in you.Accounts)
                        {
                            var type = "";
                            if(account is CurrentAccount)
                            {
                                type = "Current";
                            }
                            if(account is SavingsAccount)
                            {
                                type = "Savings";
                            }
                            Console.WriteLine("{0,10}{1,20}{2,25}",account.AccountNumber,type,account.Balance.ToString("C2"));

                        }

                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();

                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 7:
                        if (you.IsVIP)
                        {
                            for (int i = 0; i < 1000; i++)
                            {
                                Console.WriteLine($"CONGRATULATIONS {you.Name}!  YOU ARE A VIP!!");
                            }
                                                        
                            Console.Write("");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Sorry, you are not a VIP yet.");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.ReadLine();
                            Console.Clear();
                        }
                        break;

                    case 8:
                        Console.Write("Are you sure you want to leave the bank?  (Y/N)");
                        Console.WriteLine();
                        var quit = Console.ReadLine();
                        quit = quit.ToUpper();
                        if (quit == "Y")
                        {
                            Console.WriteLine("Leaving Bank ... ");
                            System.Threading.Thread.Sleep(1500);
                            Console.Beep(3007, 80);
                            // Console.Beep(3007, 80);
                            Console.Beep(2600, 100);

                            Console.WriteLine("Bye-Bye!");
                            leave = true;
                            break;

                        }
                        else
                        {
                            break;
                        }
                }
            }
        }
    }
}
