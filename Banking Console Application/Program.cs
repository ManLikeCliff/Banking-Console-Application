using System;

namespace Banking_Console_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount bankAccount = new BankAccount( money: 100, name: "Cliff");

            bankAccount.AddMoney(amount: 50);

            bankAccount.getInfo();

            bankAccount.Subtract(Money: 100);

            bankAccount.getInfo();
        }
    }
}
