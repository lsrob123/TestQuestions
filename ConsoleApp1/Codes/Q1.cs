using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Codes
{
    public class Prefix
    {
        public static IEnumerable<string> Prefixes(IEnumerable<string> words, int length)
        {
            var result=words.Where(x=>x.Length>=length).Select(x=>x.Substring(0,length)).Distinct();
            return result;
        }

        public static void Run()
        {
            foreach (var p in Prefixes(new string[] { "many", "manly", "men", "maybe", "my" }, 3))
                Console.WriteLine(p);
        }
    }
}
