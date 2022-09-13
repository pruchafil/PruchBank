using System.IO;
using System.Text.Json;

namespace PruchBankLogic.FileSystem
{
	static class JsonSolver
	{
		public static T GetObject<T>(string path)
		{
			return (T)JsonSerializer.Deserialize
			(
				File.ReadAllText(path),
				typeof(T),
				new JsonSerializerOptions() { WriteIndented = true }
			);
		}

		public static void WriteObject<T>(string path, T obj)
		{
			File.WriteAllText
			(
				path,
				JsonSerializer.Serialize
				(
					obj,
					typeof(T),
					new JsonSerializerOptions() { WriteIndented = true }
				)
			);
		}
	}
}
