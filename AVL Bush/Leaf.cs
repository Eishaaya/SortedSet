using System;
using System.Collections.Generic;
using System.Text;

namespace AVL_Bush
{
    class Leaf<T>
        where T: IComparable
    {
        public T value;
        public Leaf<T> parent;
        public Leaf<T> left;
        public Leaf<T> right;
        public int depth;
        public Leaf(T v)
        {
            value = v;
            depth = 1;
        }
        public Leaf<T> other (Leaf<T> leaf)
        {
            Leaf<T> parent = leaf.parent;
            if(leaf == parent.left)
            {
                return parent.right;
            }
            else
            {
                return parent.left;
            }
        }
        public bool isleft ()
        {
            if (parent.left == this)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
