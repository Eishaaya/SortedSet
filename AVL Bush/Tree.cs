using System;
using System.Collections.Generic;
using System.Text;

namespace AVL_Bush
{
    class Tree<T>
        where T : IComparable
    {
        public Leaf<T> root;

        public Tree()
        {
            root = null;
        }

        public Leaf<T> find(T value)
        {
            if (root == null)
            {
                return null;
            }
            Leaf<T> traveller = root;
            while (true)
            {
                if (traveller.value.Equals(value))
                {
                    return traveller;
                }
                if (traveller.value.CompareTo(value) > 0)
                {
                    if (traveller.left == null)
                    {
                        return null;
                    }
                    else
                    {
                        traveller = traveller.left;
                    }
                }
                else
                {
                    if (traveller.right == null)
                    {
                        return null;
                    }
                    else
                    {
                        traveller = traveller.right;
                    }
                }
            }
        }
        public bool contains(T value)
        {
            if (find(value) == null)
            {
                return false;
            }
            return true;
        }
        public void add(T value)
        {
            if (root == null)
            {
                root = new Leaf<T>(value);
                return;
            }
            else
            {
                add(value, root);
            }
        }
        public void add(T value, Leaf<T> traveller)
        {
            if (value.CompareTo(traveller.value) >= 0)
            {
                if (traveller.right == null) // right addition
                {
                    traveller.right = new Leaf<T>(value);
                    traveller.right.parent = traveller;
                }
                else
                {
                    add(value, traveller.right);
                }
            }
            else
            {
                if (traveller.left == null) // left addition
                {
                    traveller.left = new Leaf<T>(value);
                    traveller.left.parent = traveller;
                }
                else
                {
                    add(value, traveller.left);
                }
            }
            Hupdate(traveller);
            balance(traveller);
        }
        public void Hupdate(Leaf<T> node)
        {
            node.depth = Math.Max(node.right != null ? node.right.depth : 0, node.left != null ? node.left.depth : 0) + 1;
        }
        public void balance(Leaf<T> node)
        {
            if ((node.right != null ? node.right.depth : 0) > (node.left != null ? node.left.depth + 1 : 1))
            {
                rotateLeft(node);
                return;
            }
            if ((node.left != null ? node.left.depth : 0) > (node.right != null ? node.right.depth + 1 : 1))
            {
                rotateRight(node);
            }

        }
        public void rotateLeft(Leaf<T> node)
        {
            if (node.right.left != null)
            {
                rotateRight(node.right);
            }
            if (node == root)
            {
                node.right.parent = null;
                node.parent = node.right;
                node.right = node.right.left;
                node.parent.left = node;
                root = node.parent;
                Hupdate(node);
                Hupdate(node.parent);
                return;
            }
            if (node.isleft())
            {
                node.parent.left = node.right;
            }
            else
            {
                node.parent.right = node.right;
            }
            node.right.parent = node.parent;
            node.parent = node.right;
            node.right = node.right.left;
            node.parent.left = node;
            Hupdate(node);
            Hupdate(node.parent);
        }
        public void rotateRight(Leaf<T> node)
        {
            if (node.left.right != null)
            {
                rotateLeft(node.left);
            }
            if (node == root)
            {
                node.left.parent = null;
                node.parent = node.left;
                node.left = node.left.right;
                node.parent.right = node;
                root = node.parent;
                Hupdate(node);
                Hupdate(node.parent);
                return;
            }
            if (node.isleft())
            {
                node.parent.left = node.left;
            }
            else
            {
                node.parent.right = node.left;
            }
            node.left.parent = node.parent;
            node.parent = node.left;
            node.left = node.left.right;
            node.parent.right = node;
            Hupdate(node);
            Hupdate(node.parent);
        }
        public bool remove(T v)
        {
            if (!contains(v))
            {
                return false;
            }
            remove(v, root, true);
            return true;
        }
        public void remove(T value, Leaf<T> traveller, bool isRoot)
        {
            if (traveller.value.Equals(value)) // deletion code
            {
                if (traveller.left == null && traveller.right == null) // no kids
                {
                    if (isRoot)
                    {
                        root = null;
                        return;
                    }
                    if (traveller.parent.right == traveller)
                    {
                        traveller.parent.right = null;
                    }
                    else
                    {
                        traveller.parent.left = null;
                    }
                    traveller = null;
                    return;
                }
                else if (traveller.left != null && traveller.right != null) // two kids
                {
                    Leaf<T> replacer = traveller.right;
                    while (replacer.left != null)
                    {
                        replacer = replacer.left;
                    }
                    traveller.value = replacer.value;
                    replacer.parent.right = null;
                    replacer = null;
                    if (isRoot)
                    {
                        root = traveller;
                    }
                    return;
                }
                else if (traveller.left == null) // only right
                {
                    Leaf<T> replacer = traveller.right;
                    while (replacer.left != null)
                    {
                        replacer = replacer.left;
                    }
                    traveller.value = replacer.value;
                    replacer.parent.right = null;
                    replacer = null;
                    if (isRoot)
                    {
                        root = traveller;
                    }
                    return;
                }
                else // only left
                {
                    Leaf<T> replacer = traveller.left;
                    while (replacer.right != null)
                    {
                        replacer = replacer.right;
                    }
                    traveller.value = replacer.value;
                    replacer.parent.right = null;
                    replacer = null;
                    if (isRoot)
                    {
                        root = traveller;
                    }
                    return;
                }
            }
            else // Travel code
            {
                if (value.CompareTo(traveller.value) >= 0)
                {
                    remove(value, traveller.right, false);
                    Hupdate(traveller);
                    balance(traveller);
                }
                else
                {
                    remove(value, traveller.left, false);
                    Hupdate(traveller);
                    balance(traveller);
                }
            }
        }
    }
}
