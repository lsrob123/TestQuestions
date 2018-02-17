using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp1.Codes
{
    public class Q3
    {
        public static async Task RunAsync()
        {
            var q = new ConcurrentQueue<string>();
            //await Task.WhenAll(new List<Task>
            //{
            //    Task1(q),
            //    Task2(q)
            //});

            await Task.WhenAll(AllTasks(q))
                .ContinueWith(t =>
                {
                    while (q.TryDequeue(out var item))
                        Console.WriteLine(item);
                });
        }

        private static IEnumerable<Task> AllTasks(ConcurrentQueue<string> q)
        {
            return new List<Task> {Task1(q), Task2(q)};
        }

        private static Task Task2(ConcurrentQueue<string> q)
        {
            return Task.Run(() => q.Enqueue("t-2"));
        }

        private static Task Task1(ConcurrentQueue<string> q)
        {
            return Task.Run(() =>
            {
                q.Enqueue("t-1");
                return Guid.NewGuid();
            }).ContinueWith(t => q.Enqueue(t.Result.ToString()));
        }
    }
}