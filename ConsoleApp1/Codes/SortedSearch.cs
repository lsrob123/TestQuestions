using System;

namespace ConsoleApp1.Codes
{
    /// <summary>
    ///     Implement function CountNumbers that accepts a sorted array of integers and
    ///     counts the number of array elements that are less than the parameter lessThan.
    ///     For example, SortedSearch.CountNumbers(new int[] { 1, 3, 5, 7 }, 4) should return 2
    ///     because there are two array elements less than 4.
    /// </summary>
    public class SortedSearch
    {
        public static int CountNumbers(int[] sortedArray, int lessThan)
        {
            if (sortedArray == null || sortedArray.Length == 0)
                return 0;

            var len = sortedArray.Length;
            if (len == 1)
                return sortedArray[0] < lessThan ? 1 : 0;

            var end = len - 1;
            var upperBound = end;
            var lowerBound = 0;

            //if (upperBound == 1)
            //{
            //    if (sortedArray[1] == lessThan)
            //        return 1;

            //    if (sortedArray[1] < lessThan)
            //        return 2;
            //}

            while (lowerBound <= upperBound)
            {
                var mid = (upperBound + lowerBound) / 2;
                var midValue = sortedArray[mid];

                if (midValue <= lessThan)
                    if (mid == 0 || mid == end || sortedArray[mid + 1] > lessThan)
                        return midValue == lessThan ? mid : mid + 1;

                if (lessThan < midValue)
                    upperBound = mid - 1;
                else
                    lowerBound = mid + 1;
            }
            return 0;
        }

        public static void Run()
        {
            Console.WriteLine(CountNumbers(null, 4));
            Console.WriteLine(CountNumbers(new int[0], 4));
            Console.WriteLine(CountNumbers(new[] { 3 }, 4));
            Console.WriteLine(CountNumbers(new[] { 4 }, 4));
            Console.WriteLine(CountNumbers(new[] { 5 }, 4));
            Console.WriteLine(CountNumbers(new[] { 1, 3, 5, 7 }, 4));
            Console.WriteLine(CountNumbers(new[] { 1, 3, 4, 5, 7 }, 4));
            Console.WriteLine(CountNumbers(new[] { 1, 5 }, 4));
            Console.WriteLine(CountNumbers(new[] { 1, 2, 3 }, 4));
            Console.WriteLine(CountNumbers(new[] { 4, 5 }, 4));
            Console.WriteLine(CountNumbers(new[] { 1, 3, 4 }, 4));
            Console.WriteLine(CountNumbers(new[] { 4, 5, 7, 8 }, 4));
            Console.WriteLine(CountNumbers(new[] { 5, 7, 8 }, 4));
        }
    }
}