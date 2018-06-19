using System;
using System.Collections.Generic;
using System.Linq;

namespace WordToAnagram
{
    /// <summary>
    /// Anagram Kata
    /// </summary>
    /// <remarks>
    /// Goal: Write a program that generates all two-word anagrams of the string “documenting”.
    /// The word list to use is included with the program.
    /// The focus for this kata is for self-documenting code.
    /// </remarks>
    public class Program
    {
        static void Main(string[] args)
        {
            var wordToAnagram = "documenting";

            var wordList = FileToLines(".\\wordlist.txt").ToWords();

            foreach (var firstWord in wordList)
                foreach (var secondWord in wordList)
                    if (wordToAnagram.IsSatisfiedBy(firstWord + secondWord))
                        Display(wordToAnagram + " = " + firstWord + " " + secondWord);
        }

        private static string[] FileToLines(string path)
        {
            return System.IO.File.ReadAllLines(path);
        }

        private static void Display(string message)
        {
            Console.WriteLine(message);
        }
    }

    public static class Extensions
    {
        public static List<string> ToWords(this string[] lines)
        {
            List<string> words = new List<string>();
            foreach (var line in lines)
                foreach (var word in line.Split(" ", StringSplitOptions.RemoveEmptyEntries))
                    words.Add(word);
            return words;
        }

        public static bool IsSatisfiedBy(this string wordToAnagram, string firstWordPlusSecondWord)
        {
            return wordToAnagram.Sorted() == firstWordPlusSecondWord.Sorted();
        }

        public static string Sorted(this string word)
        {
            return string.Concat(word.OrderBy(c => c));
        }
    }
}
