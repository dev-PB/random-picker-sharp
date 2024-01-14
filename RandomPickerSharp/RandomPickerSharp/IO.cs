using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

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

        public static void OutputSongInfo(string url, string playerName)
        {
            Console.WriteLine($"Next song: {url}\nPicked by: {playerName}");
        }

        public static bool GetYesOrNo(string message)
        {
            Console.WriteLine(message);
            string? input = Console.ReadLine()?.Trim().ToUpper();

            switch (input)
            {
                case "YES":
                case "Y":
                        return true;
                case "NO":
                case "N":
                        return false;
                default:
                    return GetYesOrNo(message);
            }
        }

        public static void PrintScoreBoard(int correctGuesses, int totalSongs, List<string> scores)
        {
            Console.WriteLine($"{correctGuesses} out of {totalSongs} songs were guessed correctly.");
            scores.ForEach(i => Console.WriteLine(i));
        }
    }
}
