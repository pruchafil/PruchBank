namespace PruchBankLogic.FileSystem
{
	class Config
	{
		private const string _path = @"Files\Config.json";

		public static Config GlobalConfig { get; }

		static Config()
		{
			GlobalConfig = JsonSolver.GetObject<Config>(_path);
		}

		public decimal InterestRate { get; set; }
		public decimal DecreaseRate { get; set; }
		public decimal CreditLine { get; set; }
	}
}
