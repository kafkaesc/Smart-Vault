using Dapper;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SmartVault.Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SQLite;
using System.IO;
using System.Xml.Serialization;

namespace SmartVault.DataGeneration
{
	partial class Program
	{
		static void Main(string[] args)
		{
			var configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json").Build();

			SQLiteConnection.CreateFile(configuration["DatabaseFileName"]);
			File.WriteAllText("TestDoc.txt", $"This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}This is my test document{Environment.NewLine}");

			using (var connection = new SQLiteConnection(
				string.Format(
					configuration?["ConnectionStrings:DefaultConnection"] ?? "",
					configuration?["DatabaseFileName"]
				))
			)
			{
				// Windows
				// var files = Directory.GetFiles(@"..\..\..\..\BusinessObjectSchema");
				// macOS/Linux
				var files = Directory.GetFiles(@"../../../../BusinessObjectSchema");

				for (int i = 0; i <= 2; i++)
				{
					var serializer = new XmlSerializer(typeof(BusinessObject));
					var businessObject = serializer
						.Deserialize(new StreamReader(files[i])) as BusinessObject;
					connection.Execute(businessObject?.Script);
				}

				/* Insert User and Account rows first, in a single loop */
				for (int i = 0; i < 100; i += 10)
				{
					var randomDayIterator = RandomDay().GetEnumerator();
					randomDayIterator.MoveNext();
					connection.Execute(InsertUserString(i, randomDayIterator));
					connection.Execute(InsertAccountString(i));

					randomDayIterator = RandomDay().GetEnumerator();
					randomDayIterator.MoveNext();
					connection.Execute(InsertUserString(i + 1, randomDayIterator));
					connection.Execute(InsertAccountString(i + 1));

					randomDayIterator = RandomDay().GetEnumerator();
					randomDayIterator.MoveNext();
					connection.Execute(InsertUserString(i + 2, randomDayIterator));
					connection.Execute(InsertAccountString(i + 2));

					randomDayIterator = RandomDay().GetEnumerator();
					randomDayIterator.MoveNext();
					connection.Execute(InsertUserString(i + 3, randomDayIterator));
					connection.Execute(InsertAccountString(i + 3));

					randomDayIterator = RandomDay().GetEnumerator();
					randomDayIterator.MoveNext();
					connection.Execute(InsertUserString(i + 4, randomDayIterator));
					connection.Execute(InsertAccountString(i + 4));

					randomDayIterator = RandomDay().GetEnumerator();
					randomDayIterator.MoveNext();
					connection.Execute(InsertUserString(i + 5, randomDayIterator));
					connection.Execute(InsertAccountString(i + 5));

					randomDayIterator = RandomDay().GetEnumerator();
					randomDayIterator.MoveNext();
					connection.Execute(InsertUserString(i + 6, randomDayIterator));
					connection.Execute(InsertAccountString(i + 6));

					randomDayIterator = RandomDay().GetEnumerator();
					randomDayIterator.MoveNext();
					connection.Execute(InsertUserString(i + 7, randomDayIterator));
					connection.Execute(InsertAccountString(i + 7));

					randomDayIterator = RandomDay().GetEnumerator();
					randomDayIterator.MoveNext();
					connection.Execute(InsertUserString(i + 8, randomDayIterator));
					connection.Execute(InsertAccountString(i + 8));

					randomDayIterator = RandomDay().GetEnumerator();
					randomDayIterator.MoveNext();
					connection.Execute(InsertUserString(i + 9, randomDayIterator));
					connection.Execute(InsertAccountString(i + 9));
				}

				/* Insert documents in the nested loop using SQLite Command 
				 * for a batch insert */
				connection.Open();
				SQLiteCommand sqlCommand;
				sqlCommand = new SQLiteCommand("begin", connection);
				sqlCommand.ExecuteNonQuery();
				var documentNumber = 0;
				for (int i = 0; i < 100; i++)
				{
					var documentPath = new FileInfo("TestDoc.txt").FullName;
					for (int d = 0; d < 10000; d += 10, documentNumber += 10)
					{
						sqlCommand.CommandType = CommandType.Text;
						sqlCommand.CommandText = InsertDocumentString(documentNumber, i, d, documentPath);
						sqlCommand.ExecuteNonQuery();
						sqlCommand.CommandType = CommandType.Text;
						sqlCommand.CommandText = InsertDocumentString(documentNumber + 1, i + 1, d, documentPath);
						sqlCommand.ExecuteNonQuery();
						sqlCommand.CommandType = CommandType.Text;
						sqlCommand.CommandText = InsertDocumentString(documentNumber + 2, i + 2, d, documentPath);
						sqlCommand.ExecuteNonQuery();
						sqlCommand.CommandType = CommandType.Text;
						sqlCommand.CommandText = InsertDocumentString(documentNumber + 3, i + 3, d, documentPath);
						sqlCommand.ExecuteNonQuery();
						sqlCommand.CommandType = CommandType.Text;
						sqlCommand.CommandText = InsertDocumentString(documentNumber + 4, i + 4, d, documentPath);
						sqlCommand.ExecuteNonQuery();
						sqlCommand.CommandType = CommandType.Text;
						sqlCommand.CommandText = InsertDocumentString(documentNumber + 5, i + 5, d, documentPath);
						sqlCommand.ExecuteNonQuery();
						sqlCommand.CommandType = CommandType.Text;
						sqlCommand.CommandText = InsertDocumentString(documentNumber + 6, i + 6, d, documentPath);
						sqlCommand.ExecuteNonQuery();
						sqlCommand.CommandType = CommandType.Text;
						sqlCommand.CommandText = InsertDocumentString(documentNumber + 7, i + 7, d, documentPath);
						sqlCommand.ExecuteNonQuery();
						sqlCommand.CommandType = CommandType.Text;
						sqlCommand.CommandText = InsertDocumentString(documentNumber + 8, i + 8, d, documentPath);
						sqlCommand.ExecuteNonQuery();
						sqlCommand.CommandType = CommandType.Text;
						sqlCommand.CommandText = InsertDocumentString(documentNumber + 9, i + 9, d, documentPath);
						sqlCommand.ExecuteNonQuery();
					}
				}

				sqlCommand = new SQLiteCommand("end", connection);
				sqlCommand.ExecuteNonQuery();

				var accountData = connection.Query("SELECT COUNT(*) FROM Account;");
				Console.WriteLine($"AccountCount: {JsonConvert.SerializeObject(accountData)}");
				var documentData = connection.Query("SELECT COUNT(*) FROM Document;");
				Console.WriteLine($"DocumentCount: {JsonConvert.SerializeObject(documentData)}");
				var userData = connection.Query("SELECT COUNT(*) FROM User;");
				Console.WriteLine($"UserCount: {JsonConvert.SerializeObject(userData)}");
			}
		}

		private static String InsertAccountString(int id)
		{
			return $"INSERT INTO Account (Id, Name, DateCreated) VALUES('{id}','Account{id}', CURRENT_TIMESTAMP)";
		}

		private static String InsertDocumentString(int documentNumber, int i, int d, String documentPath)
		{
			return $"INSERT INTO Document (Id, Name, FilePath, Length, AccountId, DateCreated) VALUES('{documentNumber}','Document{i}-{d}.txt','{documentPath}','{new FileInfo(documentPath).Length}','{i}', CURRENT_TIMESTAMP)";
		}

		private static String InsertUserString(int id, IEnumerator<DateTime>? randomDayIterator)
		{
			if (randomDayIterator == null)
				return "";
			return $"INSERT INTO User (Id, FirstName, LastName, DateOfBirth, AccountId, Username, Password, DateCreated) VALUES('{id}','FName{id}','LName{id}','{randomDayIterator.Current.ToString("yyyy-MM-dd")}','{id}','UserName-{id}','e10adc3949ba59abbe56e057f20f883e', CURRENT_TIMESTAMP)";
		}

		static IEnumerable<DateTime> RandomDay()
		{
			DateTime start = new DateTime(1985, 1, 1);
			Random gen = new Random();
			int range = (DateTime.Today - start).Days;
			while (true)
				yield return start.AddDays(gen.Next(range));
		}
	}
}