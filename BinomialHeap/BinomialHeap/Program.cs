using System;

namespace BinomialHeap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinomialHeap bh = new();
            Random r = new Random();
            List<BinomialTree> trees = new() { new(1), new(2)};
            /*
            for (int i = 0; i < 100; i++)
            {
                trees.Add(new(r.Next(100)));
            }
            */

            trees.ForEach(tree => bh.Insert(tree));
            
            bh.Print();
            bh.ExtractMin();
            bh.Print();
        }
    }
}