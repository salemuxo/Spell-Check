// Spell Check Starter
// This start code creates two lists
// 1: dictionary: an array containing all of the words from "dictionary.txt"
// 2: aliceWords: an array containing all of the words from "AliceInWonderland.txt"

using System;
using System.Text.RegularExpressions;
using static SearchLib.SearchMethods; // import search library

class Program
{
    public static void Main(string[] args)
    {
        // Load data files into arrays
        String[] dictionary = System.IO.File.ReadAllLines(@"data-files/dictionary.txt");
        String aliceText = System.IO.File.ReadAllText(@"data-files/AliceInWonderLand.txt");
        String[] aliceWords = Regex.Split(aliceText, @"\s+");

        // Print first 50 values of each list to verify contents
        // Console.WriteLine("***DICTIONARY***");
        // printStringArray(dictionary, 0, 50);

        // Console.WriteLine("***ALICE WORDS***");
        // printStringArray(aliceWords, 0, 50);
        Console.Clear();
        while (true)
        {
            WriteMenu();

            Console.Write("Enter menu selection (1-5): ");
            string menuSel = Console.ReadLine();
            switch (menuSel)
            {
                case "1": // linear spell check
                    {
                        Console.Write("Enter word to search for: ");
                        string searchWord = Console.ReadLine().ToLower();

                        Console.WriteLine();
                        Console.WriteLine("Linear Search starting...");
                        decimal startTime = GetCurrentTime();
                        int searchIndex = LinearSearchStr(dictionary, searchWord);
                        decimal endTime = GetCurrentTime();

                        if (searchIndex != -1)
                        {
                            Console.WriteLine($"{searchWord} is in the dictionary at position {searchIndex}. ({endTime - startTime} seconds)");
                        }
                        else
                        {
                            Console.WriteLine($"{searchWord} is not in the dictionary. ({endTime - startTime} seconds)");
                        }
                    }
                    break;
                case "2": // binary spell check
                    {
                        Console.Write("Enter word to search for: ");
                        string searchWord = Console.ReadLine().ToLower();

                        Console.WriteLine();
                        Console.WriteLine("Binary Search starting...");
                        decimal startTime = GetCurrentTime();
                        int searchIndex = BinarySearchStr(dictionary, searchWord);
                        decimal endTime = GetCurrentTime();

                        if (searchIndex != -1)
                        {
                            Console.WriteLine($"{searchWord} is in the dictionary at position {searchIndex}. ({endTime - startTime} seconds)");
                        }
                        else
                        {
                            Console.WriteLine($"{searchWord} is not in the dictionary. ({endTime - startTime} seconds)");
                        }
                    }
                    break;
                case "3": // linear check alice
                    {
                        int badWords = 0;
                        Console.WriteLine();
                        Console.WriteLine("Linear Search starting...");

                        decimal startTime = GetCurrentTime();
                        foreach (String word in aliceWords)
                        {
                            if (LinearSearchStr(dictionary, word.ToLower()) == -1)
                            {
                                badWords++;
                            }
                        }
                        decimal endTime = GetCurrentTime();
                        Console.WriteLine($"{badWords} not found in dictionary ({endTime - startTime} seconds)");
                    }
                    break;
                case "4": // bianry check alice
                    {
                        int badWords = 0;
                        Console.WriteLine();
                        Console.WriteLine("Binary Search starting...");

                        decimal startTime = GetCurrentTime();
                        foreach (String word in aliceWords)
                        {
                            if (BinarySearchStr(dictionary, word.ToLower()) == -1)
                            {
                                badWords++;
                            }
                        }
                        decimal endTime = GetCurrentTime();
                        Console.WriteLine($"{badWords} not found in dictionary ({endTime - startTime} seconds)");
                    }
                    break;
                case "5": // exit
                    return;
                default:
                    Console.WriteLine("Invalid input.");
                    break;
            }
        }
    }

    public static void printStringArray(String[] array, int start, int stop)
    {
        // Print out array elements at index values from start to stop 
        for (int i = start; i < stop; i++)
        {
            Console.WriteLine(array[i]);
        }
    }

    public static void WriteMenu()
    {
        Console.WriteLine();
        Console.WriteLine("Main Menu");
        Console.WriteLine("1: Spell Check Word (Linear Search)");
        Console.WriteLine("2: Spell Check Word (Binary Search)");
        Console.WriteLine("3: Spell Check Alice In Wonderland (Linear Search)");
        Console.WriteLine("4: Spell Check Alice In Wonderland (Binary Search)");
        Console.WriteLine("5: Exit");
    }

    // return current time in seconds
    public static decimal GetCurrentTime()
    {
        decimal timeInSeconds = DateTime.Now.Ticks / (decimal)TimeSpan.TicksPerSecond;
        return timeInSeconds;
    }
}