using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinomialHeap
{
    internal class Node
    {
        private Node parent;
        private int key;

        public Node Parent { get; set; }
        public int Key { get; set; }
        private List<Node> siblings = new List<Node>();
        public List<Node> Siblings { get; }
        private Node child;
        public Node Child { get; set; }
        private int degree;
        public int Degree { get;  set; }

        public Node(Node parent, int key)
        {
            this.parent = parent;
            this.key = key;
        }
    }
}
