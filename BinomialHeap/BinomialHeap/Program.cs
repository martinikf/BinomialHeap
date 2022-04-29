BinomialHeap bh = new();

for (var i = 0; i < 4096; i++)
{
    bh.Insert(new BinomialTree(Random.Shared.Next(10000) - 5000));
    Console.WriteLine(bh.Size);
}

bh.Print();

for (var i = 0; i < 4096; i++)
{
    Console.WriteLine(bh.ExtractMin().Key);
    //Console.WriteLine(bh.Size);
    //bh.Print();
}

Console.ReadLine();

internal class BinomialHeap
{
    private List<BinomialTree> _heap;

    public BinomialHeap()
    {
        this._heap = new List<BinomialTree>();
    }

    public BinomialHeap(List<BinomialTree> heap)
    {
        this._heap = heap;
    }

    public uint Size { get; set; }

    public BinomialTree Min()
    {
        var min = _heap[0];
        foreach (var tree in _heap)
        {
            if (tree.Key < min.Key)
                min = tree;
        }
        return min;
    }

    private BinomialTree BinomialLink(BinomialTree y, BinomialTree z)
    {
        var top = z;
        var bot = y;
        if (y.Key < z.Key)
        {
            top = y;
            bot = z;
        }

        top.Parent = null;
        top.Siblings.Clear();

        bot.Parent = top;
        bot.Siblings.Clear();

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
        var trees = Merge(h);
        var i = 0;
        while (i + 1 < trees.Count)
        {
            if (trees[i].Degree != trees[i + 1].Degree)
            {
                i += 1;
            }
            else
            {
                //3 trees with same degree 
                if (i + 2 < trees.Count && trees[i].Degree == trees[i + 1].Degree && trees[i + 1].Degree == trees[i + 2].Degree)
                {
                    var newTree = BinomialLink(trees[i + 1], trees[i + 2]);
                    trees[i + 1] = newTree;
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
        this._heap = trees;
    }

    private List<BinomialTree> Merge(BinomialHeap h)
    {
        List<BinomialTree> trees = new();
        int it1 = 0, it2 = 0;
        while (true)
        {
            if (it1 >= _heap.Count && it2 >= h._heap.Count)
            {
                break;
            }
            else if (it1 >= _heap.Count)
            {
                trees.Add(h._heap[it2++]);
                continue;
            }
            else if (it2 >= h._heap.Count)
            {
                trees.Add(_heap[it1++]);
                continue;
            }

            trees.Add(_heap[it1].Degree < h._heap[it2].Degree ? _heap[it1++] : h._heap[it2++]);
        }

        return trees;
    }

    public void Insert(BinomialTree t)
    {
        var newHeap = new BinomialHeap(new List<BinomialTree>() { t });
        Size++;
        this.Union(newHeap);
    }

    private void DeleteMin(BinomialTree? t)
    {
        if (t == null) return;

        Size--;
        if (t.LeftChild == null)
        {
            this._heap.Remove(t);
            return;
        }

        var newHeap = new BinomialHeap();
        List<BinomialTree> newList = new() { t.LeftChild };

        newList.AddRange(t.LeftChild.Siblings);

        newList.Reverse();
        newList.ForEach(x => x.Parent = null);
        newHeap._heap = newList;
        newHeap.Size = Size;
        this._heap.Remove(t);
        this.Union(newHeap);
    }

    public BinomialTree ExtractMin()
    {
        var min = this.Min();
        DeleteMin(min);
        return min;
    }

    public void Print()
    {
        Console.WriteLine($"Heap, keys: {Size}, trees: {_heap.Count}");
        _heap.ForEach(x =>
        {
            Console.WriteLine("\nTree");
            x.Print(true);
        });
    }
}

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
        Siblings = new List<BinomialTree>();
    }

    public void Print(bool printSibs)
    {
        Console.Write($"[{Key}:{Degree}]");
        LeftChild?.Print(true);
        Console.WriteLine();

        if (!printSibs) return;

        foreach (var s in Siblings)
        {
            s.Print(false);
        }
    }

    public int CompareTo(BinomialTree? other)
    {
        return other == null ? 1 : this.Key.CompareTo(other.Key);
    }
}