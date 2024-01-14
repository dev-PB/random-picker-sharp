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

        public static string[] GetPlayerNames()
        {
            string[] names;
            do
            {
                names = GetCommaSeparatedList("Enter player names:");
            } while (names.Length < 2);

            return names;
        }
    }
}
