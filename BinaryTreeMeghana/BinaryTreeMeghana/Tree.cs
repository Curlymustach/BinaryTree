using System;
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

        public Node<T> Minimum()
        {
            Node<T> temp = Head;
            bool found = false;
            do
            {
                temp = temp.Left;
                if (temp.Left == null)
                {
                    found = true;
                }

            } while (!found);
            return temp;

        }


        public Node<T> Maximum()
        {
            Node<T> temp = Head;
            bool found = false;
            do
            {
                temp = temp.Right;
                if (temp.Right == null)
                {
                    found = true;
                }

            } while (!found);
            return temp;

        }
        //Finish dis stupid thingy
        //public void InOrderTraverse()
        //{
        //    Node<T> temp = Head;
        //    bool finished = false;
        //    do
        //    {
        //        while (temp.Left != null)
        //        {
        //            temp = temp.Left;
        //        }
        //        Console.WriteLine("{0}", temp.Value);

        //        if(temp.Right != null)
        //        {
        //            temp = temp.Right;
        //            while (temp.Left != null)
        //            {
        //                temp = temp.Left;
        //                if (temp.Left == null)
        //                {
        //                    Console.Write("{0}", temp.Value);
        //                }
        //            }
        //        }
        //        else if(temp.Right == null)
        //        {
        //            temp = temp.Parent.Right;
        //            while (temp.Left != null)
        //            {
        //                temp = temp.Left;
        //                if (temp.Left == null)
        //                {
        //                    Console.Write("{0}", temp.Value);
        //                }
        //            }

        //        }

        //    } while (!finished);


           
            //1. Travel all the way to the left
            //2. check if temp has left child, if not, print
            //3. if temp has right child, go right, then traverse all the way to the left
            //4. if temp doesn't have right child, go back to parent, check if parent has right child
            

        //}

        public void InOrderTraverseRecursive(Node<T> node)
        {
            Node<T> temp = node;
            if(node != null)
            {
                if (temp.Left != null)
                {
                    InOrderTraverseRecursive(temp.Left);
                }
                Console.Write("{0}, ", temp.Value);
                if(temp.Right != null)
                {
                    //temp = temp.Right;
                    InOrderTraverseRecursive(temp.Right);
                }
            }

        }
    }
}
