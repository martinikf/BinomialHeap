using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinomialHeap
{
    internal class BinomialHeap
    { 
        private List<BinomialTree> heap = new List<BinomialTree>();




        public void Insert(Node node)
        {

        }

        public void IncreaseKey(Node node, int key)
        {

        }

        public void Delete(Node node)
        {

        }

        public int Min()
        {
            int min = int.MaxValue;
            foreach(var tree in heap)
            {
                if(tree.Root.Key < min)
                    min = tree.Root.Key;
            }
            return min;
        }

        public void ExtractMin()
        {

        }

        private void Union()
        {

        }
    }
}
