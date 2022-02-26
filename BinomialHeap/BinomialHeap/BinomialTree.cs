using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinomialHeap
{
    internal class BinomialTree
    {
        private Node root;
        public Node Root { get; set; }
        private int k;
        public int K { get; set; }

        public BinomialTree(Node root)
        {
            this.root = root;
        }


    }
}
