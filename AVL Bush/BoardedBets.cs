using System;
using System.Collections.Generic;
using System.Text;

namespace AVL_Bush
{
    public class BoardedBets<T>
        where T : IComparable
    {
        Tree<T> bush;

        public int Count => bush.count;
        public BoardedBets()
        {
            bush = new Tree<T>();
        }
        public void add(T newval)
        {
            bush.add(newval);
        }
        public bool remove(T newval)
        {
            return bush.remove(newval);
        }
        public Leaf<T> find(T newval)
        {
            return bush.find(newval);
        }
        public bool contains(T newval)
        {
            return bush.contains(newval);
        }
        public T min()
        {
            return minNode().value;
        }
        public T max()
        {
            return maxNode().value;
        }
        public Leaf<T> minNode()
        {
            if (bush.root == null)
            {
                return default;
            }
            Leaf<T> mover = bush.root;
            while (true)
            {
                if (mover.left != null)
                {
                    mover = mover.left;
                }
                else
                {
                    return mover;
                }
            }
        }
        public Leaf<T> maxNode()
        {
            if (bush.root == null)
            {
                return default;
            }
            Leaf<T> mover = bush.root;
            while (true)
            {
                if (mover.right != null)
                {
                    mover = mover.right;
                }
                else
                {
                    return mover;
                }
            }
        }
        public T floor(T value)
        {
            if (bush == null || bush.root == null)
            {
                throw new SortedSetException("Tree is empty/null");
            }
            return floor(value, bush.root, default);
        }
        public T floor(T value, Leaf<T> location, Leaf<T> closest)
        {
            if (location.value.CompareTo(value) >= 0)
            {
                if (location.left == null)
                {
                    if (closest == null)
                    {
                        throw new SortedSetException($"All values are larger than input");
                    }
                    return closest.value;
                }
                return floor(value, location.left, closest);
            }
            else
            {
                if (closest == null || location.value.CompareTo(closest.value) > 0)
                {
                    closest = location;
                }
                if (location.right == null)
                {                    
                    return closest.value;
                }
                return floor(value, location.right, closest);
            }
        }
        public T ceiling(T value)
        {
            if (bush == null || bush.root == null)
            {
                throw new SortedSetException("Tree is empty/null");
            }
            return ceiling(value, bush.root, default);
        }
        public T ceiling(T value, Leaf<T> location, Leaf<T> closest)
        {
            if (location.value.CompareTo(value) <= 0)
            {
                if (location.right == null)
                {
                    if (closest == null)
                    {
                        throw new SortedSetException($"All values are smaller than input");
                    }
                    return closest.value;
                }
                return ceiling(value, location.right, closest);
            }
            else
            {
                if (closest == null || location.value.CompareTo(closest.value) < 0)
                {
                    closest = location;
                }
                if (location.left == null)
                {
                    return closest.value;
                }
                return ceiling(value, location.left, closest);
            }
        }
    }
}
