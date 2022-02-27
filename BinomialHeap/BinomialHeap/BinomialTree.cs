using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinomialHeap
{
    internal class BinomialTree
    {
        public BinomialTree Parent { get; set; }
        public int Key { get; set; }
        public List<BinomialTree> Siblings { get; set; }
        public BinomialTree LeftChild { get; set; }
        public int Degree { get; set; }
       

        public BinomialTree(BinomialTree parent, int key)
        {
            this.Parent = parent;
            this.Key = key;
            Siblings = new();
        }
    }
}
