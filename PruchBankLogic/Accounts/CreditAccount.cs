using PruchBankLogic.Exceptions;
using PruchBankLogic.FileSystem;

namespace PruchBankLogic.Accounts
{
    sealed class CreditAccount : BaseAccount
    {
        public static decimal DecreaseRate { get; }
        public static decimal CreditLine { get; }

        static CreditAccount()
        {
            DecreaseRate = Config.GlobalConfig.DecreaseRate;
			CreditLine = Config.GlobalConfig.CreditLine;
        }

        public CreditAccount(string firstName, string lastName) : base(firstName : firstName, lastName : lastName)
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
				else if ((Money - ammount) <= CreditLine)
				{
					throw new MoneyException()
					{
						AccountMoney = Money,
						Argument = ammount,
						Message = MoneyException.CreditLine
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
            Money -= Money * (DecreaseRate / 100m);
		}
	}
}
