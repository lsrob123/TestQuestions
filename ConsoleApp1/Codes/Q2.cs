using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Codes
{
    public class Branches
    {
        public static int Count(params int[] tree)
        {
            var nodes=new Dictionary<int,int>();
            var branchCount = 0;
            for (var i = 0; i < tree.Length; i++)
            {
                //if (nodes.ContainsKey(i))
                //{
                //    nodes[i]++;
                //    branchCount++;
                //}
                //else
                //{
                //    nodes.Add(i,0);
                //}
                var key = tree[i];
                if (key == -1)
                    continue;

                if (nodes.ContainsKey(key))
                    continue;
                
                    nodes.Add(key, 1);
                    branchCount++;
                
            }

            return branchCount;
        }

        public static void Run()
        {
            Console.WriteLine(Branches.Count(1, 3, 1, -1, 3));
            Console.WriteLine(Branches.Count(1, 3, 1, -1, 3,4));
        }
    }
}
