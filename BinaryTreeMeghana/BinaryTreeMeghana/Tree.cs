﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeMeghana
{
    class Tree<T> where T : IComparable<T>
    {
        public Node<T> Head;

        public Tree()
        {
            Head = null;
        }

        public void Add(T value)
        {
            if (Head == null)
            {
                Head = new Node<T>(value);
            }
            else
            {
                Node<T> current = Head;
                Node<T> node = new Node<T>(value);
                bool done = false;
                do
                {
                    if (value.CompareTo(current.Value) >= 0)
                    {
                        if (current.Right == null)
                        {
                            done = true;
                            current.Right = node;
                            node.Parent = current;
                        }
                        else
                        {
                            current = current.Right;
                        }
                    }
                    else if (value.CompareTo(current.Value) < 0)
                    {
                        if (current.Left == null)
                        {
                            done = true;
                            current.Left = node;
                            node.Parent = current;
                        }
                        else
                        {
                            current = current.Left;
                        }

                    }

                } while (!done);


            }
        }

        public Node<T> Find(T value)
        {
            bool found = false;
            Node<T> temp = Head;
            do
            {
                if (value.CompareTo(temp.Value) > 0)
                {
                    if (value.CompareTo(temp.Value) == 0)
                    {
                        found = true;
                    }
                    else
                    {
                        temp = temp.Right;
                        if (temp.Right == null)
                        {
                            throw new IndexOutOfRangeException();
                        }
                    }
                }
                else if (value.CompareTo(temp.Value) < 0)
                {
                    if (value.CompareTo(temp.Value) == 0)
                    {
                        found = true;
                    }
                    else
                    {
                        temp = temp.Left;
                        if (temp.Left == null)
                        {
                            throw new IndexOutOfRangeException();
                        }
                    }
                }

            } while (!found);

            return temp;
        }

        public Node<T> FindParent(T value)
        {
            return Find(value).Parent;
        }

        //public void FindParent(T value)
        //{
        //    bool found = false;
        //    Node<T> parent = Head;
        //    if(parent.Value.CompareTo(value) == 0)
        //    {

        //    }
        //    do
        //    {
        //        if(value.CompareTo(parent.Value) > 0)
        //        {
        //            if(parent.Right.Value.CompareTo(value) == 0)
        //            {
        //                found = true;
        //            }
        //            else
        //            {
        //                parent = parent.Right;

        //            }
        //        }
        //        else if(value.CompareTo(parent.Value) < 0)
        //        {
        //            if(parent.Left.Value.CompareTo(value) == 0)
        //            {
        //                found = true;
        //            }
        //            else
        //            {
        //                parent = parent.Left;
        //            }
        //        }


        //    } while (!found);

        //}

        public void Delete(T value)
        {
            Delete(Find(value));
        }

        public void Delete(Node<T> node)
        {
            if (node.Left == null && node.Right == null)
            {
                if (node.Value.CompareTo(node.Parent.Value) >= 0)
                {
                    node.Parent.Right = null;
                }
                else
                {
                    node.Parent.Left = null;
                }

            }
            else if (node.Left == null)
            {
                node.Parent.Right = node.Right;
            }
            else if (node.Right == null)
            {
                node.Parent.Left = node.Left;
            }
            else
            {
                bool find = false;
                Node<T> temp = node.Left;
                do
                {
                    temp = temp.Right;
                    if (temp.Right == null)
                    {
                        find = true;
                        node.Value = temp.Value;
                        temp = null;
                    }

                } while (!find);

            }
        }

    }
}