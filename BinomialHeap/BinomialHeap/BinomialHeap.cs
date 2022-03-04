using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinomialHeap
{
    internal class BinomialHeap
    {
        public List<BinomialTree> heap; //Sorted by degrees
        public BinomialHeap()
        {
            this.heap = new();
        }
        public BinomialHeap(List<BinomialTree> heap)
        {
           this.heap = heap;
        }
        public uint Size { get; set; }

        public BinomialTree Min()
        {
            BinomialTree min = null;

            if (Size > 0) {
                min = heap[0];
                foreach (var tree in heap)
                {
                    if (tree.Key < min.Key)
                        min = tree;
                }
            }
            return min;
        }

        //Determines which tree should be on top and connects them accordingly and return root
        public BinomialTree BinomialLink(BinomialTree y, BinomialTree z)
        {
            var top = z;
            var bot = y;
            if (y.Key < z.Key)
            {
                top = y;
                bot = z;
            }

            top.Parent = null;   //should be null before
            top.Siblings.Clear(); //should be empty list before

            bot.Parent = top;
            bot.Siblings.Clear(); //should be empty list before

            if (top.LeftChild != null)
            {
                bot.Siblings.Add(top.LeftChild);
                top.LeftChild.Siblings.ForEach(x => bot.Siblings.Add(x));
            }

            top.LeftChild = bot;
            top.Degree++;
            return top;
        }

        private void Union(BinomialHeap h)
        {
            //Create list of trees from both heaps, heaps must be sorted beforehand!
            List<BinomialTree> trees = new();
            heap.ForEach(t => trees.Add(t));
            int i = 0;
            //Merge
            foreach (var tree in h.heap)
            {
                if(tree == null) { continue; }
                else if(i >= trees.Count)
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
            while (i + 1 < trees.Count)
            {
                if( trees[i].Degree != trees[i+1].Degree)
                {
                    i += 1;
                    continue;
                }
                else
                {
                    //3 trees with same degree 
                    if(i + 2 < trees.Count && trees[i].Degree == trees[i + 1].Degree && trees[i + 1].Degree == trees[i + 2].Degree)
                    {
                        var newTree = BinomialLink(trees[i + 1], trees[i + 2]);
                        trees[i+1] = newTree;
                        trees.Remove(trees[i + 2]);
                    }
                    //2 trees with same degree
                    else
                    {
                        var newTree = BinomialLink(trees[i], trees[i + 1]);
                        trees[i] = newTree;
                        trees.Remove(trees[i + 1]);
                    }
                }
            }
            this.heap = trees;
        }

        public void Insert(BinomialTree t)
        {
            BinomialHeap newHeap = new BinomialHeap(new List<BinomialTree>() {t});
            Size++;
            this.Union(newHeap);
        }

        //Nějaka stara metoda?
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
            if(t.LeftChild != null)
                foreach(var sib in t.LeftChild.Siblings)
                {
                    newList.Add(sib);
                }
            newList.Reverse();
            newHeap.heap = newList;
            Size--;
            this.heap.Remove(t);
            this.Union(newHeap);
        }

        public BinomialTree ExtractMin()
        {
            var min = this.Min();
            Delete(min);
            return min;
        }

        public void Print()
        {
            Console.WriteLine($"Heap, keys: {Size}, trees: {heap.Count}");
            heap.ForEach(x => { 
                                  Console.WriteLine("\nTree"); 
                                  x.Print(true); 
                              });   
        }
    }
}
