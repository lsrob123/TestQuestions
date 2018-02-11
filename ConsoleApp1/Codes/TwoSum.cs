using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.Codes
{
    public class TwoSum
    {
        public static Tuple<int, int> FindTwoSum(IList<int> list, int sum)
        {
            if (list==null||list.Count<2)
                return new Tuple<int, int>(0, 0);

            //var listCount = list.Count;
            //for (var i = 0; i < listCount-1; i++)
            //{
            //    var item = list[i];
            //    for (var j = i + 1; j < listCount; j++)
            //    {
            //        var item2 = list[j];
            //        if (item+item2==sum)
            //            return new Tuple<int, int>(i,j);
            //    }
            //}


           var lookups=new Dictionary<int,int>();
            for (var i = 0; i < list.Count; i++)
            {
                var value = list[i];
                if (lookups.TryGetValue(sum - value, out var matchesIndex))
                {
                    return new Tuple<int, int>(i, matchesIndex);
                }

                lookups.Add(value,i);
            }
            return new Tuple<int, int>(0, 0);
        }

        public static void Run()
        {
            Output(FindTwoSum(new List<int> { 1, 3, 5, 7, 9 }, 12));
            //Output(FindTwoSum(new List<int> { 1, 3, 5, 13  }, 12));
            //Output(FindTwoSum(new List<int> { 1, 3, 7 }, 10));
        }

        private static void Output(Tuple<int, int> indices)
        {
            if (indices.Item1 == 0 && indices.Item2 == 0)
                Console.WriteLine("Matching results can not be found.");
            else
                Console.WriteLine(indices.Item1 + " " + indices.Item2);
        }
    }
}