using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RandomPickerSharp
{
    public static class IO
    {
        public static string[] GetCommaSeparatedList(string message)
        {
            Console.WriteLine(message);
            string? userInput;

            do
            {
                userInput = Console.ReadLine()?.Trim();
            } while (string.IsNullOrWhiteSpace(userInput));


            return userInput.Split(",");
        }

        public static string[] GetNameList(string message, int minimumAmount)
        {
            string[] names;
            do
            {
                names = GetCommaSeparatedList(message);
            } while (names.Length < minimumAmount);

            return names;
        }

        public static string[] GetPlayerNames()
        {
            return GetNameList("Enter player names:", 2);
        }
    }
}
