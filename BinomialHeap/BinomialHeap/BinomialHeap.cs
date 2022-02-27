using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinomialHeap
{
    internal class BinomialHeap
    {
        private List<BinomialTree> heap; //Sorted by degrees
        public BinomialHeap()
        {
            this.heap = new();
        }
        public BinomialHeap(List<BinomialTree> heap)
        {
           this.heap = heap;
        }
       
        public BinomialTree Min()
        {
            BinomialTree min = heap[0];
            foreach (var tree in heap)
            {
                if (tree.Key < min.Key)
                    min = tree;
            }
            return min;
        }

        //Determines which tree should be on top and connects them accordingly
        public BinomialTree BinomialLink(BinomialTree y, BinomialTree z)
        {
            // set t2 as min
            if(y.Key < z.Key)
            {
                (y, z) = (z, y);
            }

            y.Parent = z;
            y.Siblings = z.LeftChild.Siblings;
            y.Siblings.Insert(0, z.LeftChild);
            z.LeftChild = y;
            z.Degree++;

            return z;
           
        }
        private void Union(BinomialHeap h)
        {
            //Create list of trees from both heaps, heaps must be sorted beforehand!
            List<BinomialTree> trees = new();
            heap.ForEach(t => trees.Add(t));
            int i = 0;
            foreach (var tree in h.heap)
            {
                if(i >= trees.Count)
                {
                    trees.Add(tree);
                }
                else if(tree.Degree <= trees[i].Degree)
                {
                    trees.Insert(i, tree);
                }
                else
                {
                    i++;
                }
            }

            i = 0;
            while (true)
            {
                if (i + 1 >= trees.Count) break;
                else if(trees[i].Degree != trees[i+1].Degree)
                {
                    i += 1;
                    continue;
                }
                else
                {
                    if(i + 2 < trees.Count && trees[i+1].Degree == trees[i + 2].Degree)
                    {
                        var newTree = BinomialLink(trees[i+1], trees[i + 2]);
                        trees[i+1] = newTree;
                        trees.Remove(trees[i + 2]);
                        i += 1;
                    }
                    else
                    {
                        var newTree = BinomialLink(trees[i], trees[i+1]);
                        trees[i] = newTree;
                        trees.Remove(trees[i + 1]);
                        i +=1;
                    }
                }
            }
            this.heap = trees;
        }

        public void Insert(BinomialTree t)
        {
            BinomialHeap newHeap = new BinomialHeap(new List<BinomialTree>() { t});
            this.Union(newHeap);
        }

        public void DecreaseKey(BinomialTree t, int value)
        {
            if (value > t.Key) return;

            t.Key = value;
            var y = t;
            var z = y.Parent;

            while(z != null && y.Key < z.Key)
            {
                (y.Key, z.Key) = (z.Key, y.Key);
                y = z;
                z = y.Parent;
            }
        }

        public void Delete(BinomialTree t)
        {
            BinomialHeap newHeap = new BinomialHeap();
            List<BinomialTree> newList = new();

            newList.Add(t.LeftChild);
            foreach(var sib in t.LeftChild.Siblings)
            {
                newList.Add(sib);
            }
            newHeap.heap = newList;
            this.Union(newHeap);
        }

        public BinomialTree ExtractMin()
        {
            var min = this.Min();
            Delete(min);

            return min;
        }
    }
}
