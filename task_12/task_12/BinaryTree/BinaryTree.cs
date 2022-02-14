using System;
using System.Collections.Generic;
using System.Collections;

namespace task_12
{
    public class BinaryTree<T> : ICollection<T> where T : IComparable<T>
    {
        private Node<T> _root;

        public int Count
        {
            get;
            private set;
        }

        public BinaryTree()
        {
            _root = null;
        }

        public BinaryTree(IEnumerable<T> list)
        {
            foreach(T item in list)
                Add(item);
        }

        public void Add(T item)
        {
            _root = Add(_root, item);
            Count++;
        }
        private Node<T> Add(Node<T> root, T item)
        {
            if (root == null)
            {
                root = new Node<T>(item);
                return root;
            }
            else
            {
                if (item.CompareTo(root.Value) < 0)
                    root.LeftNode = Add(root.LeftNode, item);
                else
                    root.RightNode = Add(root.RightNode, item);
            }

            return root;
        }        

        public void Clear()
        {
            _root = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            return Contains(_root, item);
        }

        private bool Contains(Node<T> root, T item)
        {
            if (item.CompareTo(root.Value) == 0)
                return true;
            if (item.CompareTo(root.Value) < 0)
                return Contains(root.LeftNode, item);
            if (item.CompareTo(root.Value) > 0)
                return Contains(root.RightNode, item);

            return false;
        }

        public bool Remove(T item)
        {
            int count = Count;
            _root = Remove(_root, item);
            if(count > Count)
                return true;
            else
                return false;
        }

        private Node<T> Remove(Node<T> root, T item)
        {
            if (root == null)
                return root;

            if (item.CompareTo(root.Value) < 0)
                root.LeftNode = Remove(root.LeftNode, item);
            else if(item.CompareTo(root.Value) > 0)
                root.RightNode = Remove(root.RightNode, item);
            else
            {
                Count--;
                if (root.LeftNode == null)
                    return root.RightNode;
                else if (root.RightNode == null)
                    return root.LeftNode;

                root.Value = MinValue(root.RightNode);
                root.RightNode = Remove(root.RightNode, root.Value);
            }

            return root;
        }

        private T MinValue(Node<T> root)
        {
            if (root.LeftNode == null)
                return root.Value;
            else
                return MinValue(root.LeftNode);
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (_root == null)
                yield break;

            var stack = new Stack<Node<T>>();
            Node<T> currentNode = _root;

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
                throw new ArgumentException("Invalid array size");

            foreach (T item in this)
            {
                array[indexArray] = item;
                indexArray++;
            }
        }

        public bool IsReadOnly => throw new NotImplementedException();
    }
}
