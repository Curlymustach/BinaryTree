﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeMeghana
{
    class Node<T> where T : IComparable<T>
    {
        public T Value;
        public Node<T> Left;
        public Node<T> Right;
        public Node<T> Parent;

        public Node(T Value, Node<T> Left, Node<T> Right, Node<T> Parent)
        {
            this.Value = Value;
            this.Left = Left;
            this.Right = Right;
            this.Parent = Parent;
        }

        public Node(T Value, Node<T> Left, Node<T> Right)
        {
            this.Value = Value;
            this.Left = Left;
            this.Right = Right;
        }


        public Node(T Value)
        {
            this.Value = Value;
        }

        public bool isLeftChild()
        {
            return !isRightChild();
        }

        public bool isRightChild()
        {
            if (Parent == null) return false;
            if (Value.CompareTo(Parent.Value) >= 0)
            {
                return true;
            }
            return false;
        }

    }
}
