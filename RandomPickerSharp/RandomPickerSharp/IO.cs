﻿namespace RandomPickerSharp
{
    public static class IO
    {
        public const char delimiterCharacter = ',';

        public static string[] GetCommaSeparatedList(string message)
        {
            Console.WriteLine(message);
            string? userInput;

            do
            {
                userInput = Console.ReadLine()?.Trim();
            } while (string.IsNullOrWhiteSpace(userInput));


            return userInput.Split(delimiterCharacter);
        }

        public static string[] GetNameList(string message, int minimumAmount)
        {
            string[] names;
            do
            {
                names = GetCommaSeparatedList(message);
            } while (names.Length < minimumAmount || names.Any(i => String.IsNullOrWhiteSpace(i)));

            return names;
        }

        public static List<Uri> GetUris(string name, int? amount = null)
        {
            string[] songUrls = IO.GetNameList($"Enter song URLs for {name}", 1);

            if (amount.HasValue && songUrls.Length != amount)
            {
                Console.WriteLine($"Please enter exactly {amount} urls. (You entered {songUrls.Length})");
                return GetUris(name, amount);
            }

            List<Uri> uris = new List<Uri>();

            foreach (string urlString in songUrls)
            {
                if (!Uri.TryCreate(urlString, UriKind.Absolute, out Uri? newUri) ||
                    !(newUri?.Scheme == Uri.UriSchemeHttp || newUri?.Scheme == Uri.UriSchemeHttps))
                {
                    Console.WriteLine($"Invalid URI: {urlString}");
                    break;
                }
                else
                {
                    uris.Add(newUri);
                }
            }

            if (uris.Count == songUrls.Length)
            {
                return uris;
            }

            return GetUris(name, amount);
        }

        public static string[] GetPlayerNames()
        {
            return GetNameList("Enter player names (e.g. 'John, Steve, Mike'):", 2);
        }

        public static void OutputSongInfo(string url, string playerName)
        {
            Console.WriteLine($"Next song: {url}\nPicked by: {playerName}");
        }

        public static bool GetYesOrNo(string message)
        {
            Console.WriteLine(message + " [Y/n]");
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

        public static void WriteStartup()
        {
            Console.WriteLine("Random-Picker");
            Console.WriteLine("Made by Ryan W (https://github.com/dev-PB)");
            Console.WriteLine();
            Console.WriteLine("This code and software is without license, and thus under exclusive copyright to me. I mean I don't know why you'd want to copy, modify or redistribute this anyway, surely you've got better options?");
            Console.WriteLine("For more information: https://choosealicense.com/no-permission/");
            Console.WriteLine();
        }
    }
}
