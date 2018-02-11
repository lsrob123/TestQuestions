using System;

namespace ConsoleApp1.Codes
{
    /// <summary>
    ///     A palindrome is a word that reads the same backward or forward.
    ///     Write a function that checks if a given word is a palindrome.Character case should be ignored.
    ///     For example, IsPalindrome("Deleveled") should return true as character case should be ignored,
    ///     resulting in "deleveled", which is a palindrome since it reads the same backward and forward.
    /// </summary>
    public class Palindrome
    {
        public static bool IsPalindrome(string word)
        {
            if (string.IsNullOrEmpty(word))
                return false;

            word = word.ToLower();
            var wordLength = word.Length;
            var end = wordLength / 2;
            for (var i = 0; i < end; i++)
            {
                var c = word[i];
                var o = word[wordLength - i - 1];
                if (!c.Equals(o))
                    return false;
            }
            return true;
        }

        public static void Run()
        {
            Console.WriteLine(IsPalindrome("Deleveled"));
            Console.WriteLine(IsPalindrome("Deleeled"));
        }
    }
}