using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTellerExercise.Classes
{
	public class CurrentAccount : BankAccount
	{
		//Method (override)

		public override decimal Withdraw(decimal amountToWithdraw)
		{
			if (this.Balance - amountToWithdraw < 0)
			{
                if (this.Balance - amountToWithdraw < -90)
                {
                    //Console.WriteLine("You are totaly broke.");
                    //Console.WriteLine("You cannot complete that transaction.");
                    return this.Balance;

                }

               // this.Balance -= 10;
				//this.Balance -= amountToWithdraw;
                return base.Withdraw(amountToWithdraw+10);


            }



            return base.Withdraw(amountToWithdraw);
		}
        public CurrentAccount(BankAccount bankAccount)
        {
            var that = bankAccount;
             bankAccount = new CurrentAccount();
        }
        public CurrentAccount() { }


	}
}
