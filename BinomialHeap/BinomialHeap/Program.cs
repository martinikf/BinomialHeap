using System;

namespace BinomialHeap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinomialHeap bh = new();
            Random r = new Random();

            for (int i = 0; i < 100000; i++)
            {
                bh.Insert(new(r.Next(1000)));
            }
            for (int i = 0; i < 100000; i++)
            {
                Console.WriteLine(bh.ExtractMin().Key);
            }
            Console.ReadLine();
        }
    }
}