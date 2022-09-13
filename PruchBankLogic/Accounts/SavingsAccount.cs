using PruchBankLogic.Exceptions;
using PruchBankLogic.FileSystem;

namespace PruchBankLogic.Accounts
{
    class SavingsAccount : BaseAccount
    {
		public static decimal InterestRate { get; }

        static SavingsAccount()
        {
			InterestRate = Config.GlobalConfig.InterestRate;
        }

		public SavingsAccount(string firstName, string lastName) : base(firstName, lastName)
		{
		}

        public override void Cashout(decimal ammount)
		{
			Check();

			checked
			{
				Money -= ammount;
			}

			void Check()
			{
				if (ammount <= 0)
				{
					throw new MoneyException()
					{
						AccountMoney = Money,
						Argument = ammount,
						Message = MoneyException.LowerThanZero
					};
				}
				else if (ammount > Money)
				{
					throw new MoneyException()
					{
						AccountMoney = Money,
						Argument = ammount,
						Message = MoneyException.NotEnoughMoney
					};
				}
			}
		}

		public override void Deposit(decimal ammount)
        {
			Check();

			checked
			{
				Money += ammount;
			}

			void Check()
			{
				if (ammount <= 0)
				{
					throw new MoneyException()
					{
						AccountMoney = Money,
						Argument = ammount,
						Message = MoneyException.LowerThanZero
					};
				}
			}
        }

		public override void TriggerRate()
		{
			Money += Money * (InterestRate / 100m);
		}
	}
}