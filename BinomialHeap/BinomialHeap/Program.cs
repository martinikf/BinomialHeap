namespace BinomialHeap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinomialHeap bh = new();
            Random r = new();

            for (int i = 0; i < 4096; i++)
            {
                bh.Insert(new(r.Next(1000) - 500));
                Console.WriteLine(bh.Size);

            }
            bh.Print();
            for (int i = 0; i < 4096; i++)
            {
                bh.ExtractMin();
                Console.WriteLine(bh.Size);
                //Console.WriteLine(bh.heap.Count);
                //bh.Print();
            }

            Console.ReadLine();
        }
    }
}