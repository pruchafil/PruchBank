using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruchBankLogic.Accounts
{
	static class AccountsHandler
	{
		static AccountsHandler()
		{
			Task.Run(() => TriggerInMonth());
		}

		static event Action EndOfMonth;

		const int SecondsInDay = 86_400;

		private static async void TriggerInMonth()
		{
			while (true)
			{
				var now = DateTime.Now;
				var days = DateTime.DaysInMonth(now.Year, now.Month);

				await Task.Delay((days - now.Day) * SecondsInDay);

				EndOfMonth?.Invoke();

				foreach (var item in _accounts)
				{
					if (item is CreditAccount ca)
					{
						ca.TriggerRate();
					}
					else if (item is SavingsAccount sa)
					{
						sa.TriggerRate();
					}
				}

				await Task.Delay(SecondsInDay * 2);
			}
		}

		private static readonly HashSet<BaseAccount> _accounts = new();

		public static bool SearchByID(Guid guid, out BaseAccount acc)
		{
			var ac = _accounts.Where(x => x.ID == guid);

			return Seach(out acc, ac);
		}

		public static bool SearchByFirstName(string firstName, out BaseAccount acc)
		{
			var ac = _accounts.Where(x => x.FirstName == firstName);

			return Seach(out acc, ac);
		}

		public static bool SearchByLastName(string lastName, out BaseAccount acc)
		{
			var ac = _accounts.Where(x => x.LastName == lastName);

			return Seach(out acc, ac);
		}

		private static bool Seach(out BaseAccount acc, IEnumerable<BaseAccount> ac)
		{
			if (ac.Any())
			{
				acc = ac.First();
				return true;
			}

			acc = default;
			return false;
		}

		public static bool Add(BaseAccount account)
		{
			return _accounts.Add(account);
		}

		public static BaseAccount[] GetAccounts()
		{
			return _accounts.ToArray();
		}
	}
}