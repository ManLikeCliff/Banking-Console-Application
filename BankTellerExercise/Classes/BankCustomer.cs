using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankTellerExercise.Classes;

namespace BankTellerExercise.Classes
{
    public class BankCustomer
    {
        private List<BankAccount> acctList = new List<BankAccount>();
        private decimal count = 0;
        public string Name { get; set; }

        public bool IsVIP
        {
            get
            {
                foreach (var act in acctList)
                {
                    count += act.Balance;


                }
                if (count >= 25000)
                {
                    return true;
                }


                return false;

            }


        }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public BankAccount[] Accounts
        {
            get { return acctList.ToArray(); }
        }

        public void AddAccount(BankAccount newAccount, string name)
        {
            if (newAccount is CurrentAccount)
            {
                newAccount = new CurrentAccount
                {
                    AccountNumber = name.ToUpper()
                };

            }
            else if(newAccount is SavingsAccount)
            {
                newAccount = new SavingsAccount
                {
                    AccountNumber = name.ToUpper()
                };
            }
            //newAccount = new BankAccount();
            newAccount.AccountNumber = name;
            acctList.Add(newAccount);

        }



    }
}
