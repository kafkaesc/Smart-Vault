using System;

namespace SmartVault.Program
{
    partial class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                return;
            }

            WriteEveryThirdFileToFile(args[0]);
            GetAllFileSizes();
		}

        private static void GetAllFileSizes()
        {
            Console.WriteLine("GetAllFileSizes start");
            // TODO: Implement functionality
        }

        private static void WriteEveryThirdFileToFile(string accountId)
        {
			Console.WriteLine("WriteEveryThirdFileToFile start");
			// TODO: Implement functionality
		}
    }
}