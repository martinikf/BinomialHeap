using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinomialHeap
{
    internal class BinomialTree
    {
        private BinomialTree parent;
        private int key;

        public BinomialTree Parent { get; set; }
        public int Key { get; set; }
        private List<BinomialTree> siblings = new List<BinomialTree>();
        public List<BinomialTree> Siblings { get; }
        private BinomialTree leftChild;
        public BinomialTree Child { get; set; }
        private int degree;
        public int Degree { get; set; }

        public BinomialTree(Node parent, int key)
        {
            this.parent = parent;
            this.key = key;
        }


    }
}
