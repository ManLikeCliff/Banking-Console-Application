using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Console_Application
{
    class BankAccount
    {
        private double Money = 0;
        private readonly String name;

        public BankAccount(double money, String name)
        {
            Money = money;
            this.name = name;
        }

        public void AddMoney(double amount)
        {
            //Money = Money + amount;
            Console.WriteLine("Added " + amount + " to the bank account of " + name);
            Money += amount;
        }

        public void Subtract(double Money)
        {
            this.Money -= Money;
        }

        public void getInfo()
        {
            Console.WriteLine(name + " has " + Money);
        }
    }
}
