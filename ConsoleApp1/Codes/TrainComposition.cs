using System;
using System.Collections.Generic;

namespace ConsoleApp1.Codes
{
    public class TrainComposition
    {
        private readonly LinkedList<int> _train = new LinkedList<int>();

        public void AttachWagonFromLeft(int wagonId)
        {
            if (_train.Count == 0)
                _train.AddFirst(wagonId);
            else
                _train.AddBefore(_train.First, wagonId);
        }

        public void AttachWagonFromRight(int wagonId)
        {
            if (_train.Count == 0)
                _train.AddFirst(wagonId);
            else
                _train.AddAfter(_train.Last, wagonId);
        }

        public int DetachWagonFromLeft()
        {
            if (_train.Count == 0)
                return 0;
            var removed = _train.First;
            _train.RemoveFirst();
            return removed.Value;
        }

        public int DetachWagonFromRight()
        {
            if (_train.Count == 0)
                return 0;
            var removed = _train.Last;
            _train.RemoveLast();
            return removed.Value;
        }

        public static void Run()
        {
            var tree = new TrainComposition();
            tree.AttachWagonFromLeft(7);
            tree.AttachWagonFromLeft(13);
            Console.WriteLine(tree.DetachWagonFromRight()); // 7 
            Console.WriteLine(tree.DetachWagonFromLeft()); // 13
        }
    }
}