using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_1
{
    public class Node<T>
    {
        public T Value;
        public Node<T> LeftNode;
        public Node<T> RightNode;

        public Node(T value)
        {
            Value = value;
        }
    }
}
