using System;

namespace PruchBankLogic.Exceptions
{
    internal sealed class MoneyException : ApplicationException
    {
        public const string LowerThanZero = "You have to insert valid number. (Lower than zero exception)";
        public const string NotEnoughMoney = "You don't have enough money. (Not enough money exception)";
        public const string LimitHit = "Your limit was hit. (Bigger than limit exception)";
        public const string CreditLine = "Your limit was hit. (Credit line limit exception)";

        public new string Message { init; get; }
        public decimal AccountMoney { init; get; }
        public decimal Argument { init; get; }
    }
}
