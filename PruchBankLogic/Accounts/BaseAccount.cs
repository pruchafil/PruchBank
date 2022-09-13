using System;

namespace PruchBankLogic.Accounts
{
    abstract class BaseAccount : IComparable<BaseAccount>
    {
        public string FirstName { get; }
        public string LastName { get; }
        public Guid ID { get; } = Guid.NewGuid();

        public decimal Money { get; protected set; }

		protected BaseAccount(string firstName, string lastName)
		{
			FirstName = firstName;
			LastName = lastName;
		}

		public abstract void Deposit(decimal ammount);

        public abstract void Cashout(decimal ammount);

		public abstract void TriggerRate();

		public int CompareTo(BaseAccount other)
		{
            return ID.CompareTo(other.ID);
		}
	}
}
