using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTellerExercise.Classes
{
	public class SavingsAccount : BankAccount
	{
		//METhOD override

		public override decimal Withdraw(decimal amountToWithdraw)
		{
            if (amountToWithdraw > this.Balance)
            {
                return this.Balance;
            }

            if (this.Balance < 150)
			{
                return base.Withdraw(amountToWithdraw+2);

                //this.Balance -= 2;

			}
			

			return base.Withdraw(amountToWithdraw);
		}

        //Constructor
        public SavingsAccount()
        {

        }
      /*  public SavingsAccount(BankAccount bankAccount)
        {

           
        }*/

	}
}
