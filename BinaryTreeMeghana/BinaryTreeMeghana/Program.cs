using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeMeghana
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>();

            tree.Add(10);
            tree.Add(8);
            tree.Add(12);
            tree.Add(9);
            tree.Add(11);
            tree.Add(13);
            tree.Add(7);


            tree.Print();

            Console.ReadKey();

        }
    }
}
