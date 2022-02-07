using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;

namespace task_12
{
    public class BinaryTree<T> : ICollection<T> where T : IComparable<T>
    {
        private Node<T> root;

        public int Count
        {
            get;
            private set;
        }

        public BinaryTree()
        {
            root = null;
        }
        public BinaryTree(IEnumerable<T> list)
        {
            foreach(T item in list)
            {
                Add(item);
            }
        }

        public void Add(T item)
        {
            if (root == null)
                root = new Node<T>(item);
            else
            {
                Node<T> currentNode = root;
                Node<T> parent = null;
                while(currentNode != null)
                {
                    parent = currentNode;

                    if (item.CompareTo(currentNode.Value) < 0)
                        currentNode = currentNode.LeftNode;
                    else
                        currentNode = currentNode.RightNode;
                }

                if (item.CompareTo(root.Value) < 0)
                    parent.LeftNode = new Node<T>(item);
                else
                    parent.RightNode = new Node<T>(item);
            }

            Count++;
        }

        public void Clear()
        {
            root = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            Node<T> currentNode = root;

            while (currentNode != null)
            {
                if (item.CompareTo(currentNode.Value) < 0)
                    currentNode = currentNode.LeftNode;
                else if (item.CompareTo(currentNode.Value) > 0)
                    currentNode = currentNode.RightNode;
                else
                    return true;
            }

            return false;
        }


        public bool Remove(T item)
        {
            Node<T> currentNode = root;

            while (currentNode != null)
            {
                if (item.CompareTo(currentNode.Value) < 0)
                    currentNode = currentNode.LeftNode;
                else if (item.CompareTo(currentNode.Value) > 0)
                    currentNode = currentNode.RightNode;
                else
                {
                    currentNode.Value = currentNode.RightNode.Value;
                    currentNode.LeftNode = currentNode.RightNode.LeftNode;
                    currentNode.RightNode = currentNode.RightNode.RightNode;
                    return true;
                }
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (root == null)
                yield break;

            var stack = new Stack<Node<T>>();
            Node<T> currentNode = root;

            while (stack.Count > 0 || currentNode != null)
            {
                if (currentNode == null)
                {
                    currentNode = stack.Pop();
                    yield return currentNode.Value;
                    currentNode = currentNode.RightNode;
                }
                else
                {
                    stack.Push(currentNode);
                    currentNode = currentNode.LeftNode;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void CopyTo(T[] array, int indexArray)
        {
            if (Count > array.Length - indexArray)
                throw new ArgumentException("Invalid size array");

            foreach(T item in this)
            {
                array[indexArray] = item;
                indexArray++;
            }
        }

        public bool IsReadOnly => throw new NotImplementedException();
    }
}
