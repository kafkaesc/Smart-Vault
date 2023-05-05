using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Xml.Serialization;

namespace SmartVault.Program
{
	partial class Program
	{
		static void Main(string[] args)
		{
			if (args.Length == 0)
				return;

			WriteEveryThirdFileToFile(args[0]);
			//WriteEveryThirdFileToFile("1");
			GetAllFileSizes();
		}

		private static void GetAllFileSizes()
		{
			// TODO: Implement functionality
		}

		private static void WriteEveryThirdFileToFile(string accountId)
		{
			// TODO: Implement functionality
			using (var connection = new SQLiteConnection(
				"Data Source=../../../testdb.sqlite"
			))
			{
				connection.Open();
				SQLiteCommand command = new SQLiteCommand(connection);
				command.CommandText = $"SELECT * FROM Document ;";
				command.CommandType = CommandType.Text;
				SQLiteDataReader reader = command.ExecuteReader();
				if (reader.HasRows)
				{
					while (reader.Read())
					{
						Console.WriteLine(
							reader.GetString(1) + " " +
							reader.GetString(2) + " " +
							reader.GetInt32(3) + " " +
							reader.GetInt32(4) + " " +
							reader.GetString(5)
						);
						Console.WriteLine("--");
					}
				}
				reader.Close();
				connection.Close();
			}
		}
	}
}