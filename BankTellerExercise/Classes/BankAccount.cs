using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTellerExercise.Classes
{ //SUPER CLASS

	public class BankAccount
	{
		//properties

		public string AccountNumber { get; set; }
		public decimal Balance { get; private set; }


		//METHODS

		public decimal Deposit(decimal amountToDeposit)
		{
			return Balance += amountToDeposit;
		}

		public virtual decimal Withdraw(decimal amountToWithdraw)
		{
			return Balance -= amountToWithdraw;
		}

		public void Transfer(BankAccount destinationAcount, decimal transferAmount)
		{
            if (this.Balance >= transferAmount)
            {
                this.Balance -= transferAmount;
                destinationAcount.Balance += transferAmount;
                return;
            }
            else { return; }
		}

		//CONSTRUCTOR

		public BankAccount()
		{
			this.Balance = 0;
		}
	}
}
