using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinomialHeap
{
    internal class BinomialTree : IComparable<BinomialTree>
    {
        public BinomialTree? Parent { get; set; }
        public int Key { get; set; }
        public List<BinomialTree> Siblings { get; set; }
        public BinomialTree? LeftChild { get; set; }
        public int Degree { get; set; }
       

        public BinomialTree(int key)
        {
            Parent = null;
            this.Key = key;
            Siblings = new();
        }

        public void Print(bool printSibs)
        {
            Console.Write($"[{Key}:{Degree}]");
            if(LeftChild != null) LeftChild.Print(true);
            Console.WriteLine();
            if (printSibs)
                foreach(BinomialTree s in Siblings)
                {
                    s.Print(false);
                }
        }

        public int CompareTo(BinomialTree? other)
        {
            if(other == null) return 1;
            return this.Key.CompareTo(other.Key);
        }
    }
}
