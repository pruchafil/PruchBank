using PruchBankLogic.Exceptions;

namespace PruchBankLogic.Accounts
{
	class StudentSavingsAccount : SavingsAccount
	{
		public decimal Limit { get; }

		public StudentSavingsAccount(string firstName, string lastName, decimal limit) : base(firstName : firstName, lastName : lastName)
		{
			Limit = limit;
		}

		public override void Cashout(decimal ammount)
		{
			if (ammount > Limit)
				throw new MoneyException()
				{
					AccountMoney = Money,
					Argument = ammount,
					Message = MoneyException.LimitHit
				};

			base.Cashout(ammount);
		}
	}
}
