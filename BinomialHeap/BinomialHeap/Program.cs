using System;

namespace BinomialHeap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinomialHeap bh = new();
            Random r = new Random();

            for (int i = 0; i < 8; i++)
            {
                bh.Insert(new(i));
            }
            Console.WriteLine(bh.heap.Count); 
            bh.Print();
        }
    }
}