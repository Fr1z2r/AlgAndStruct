using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var binTree = new BinTree<int>();
            binTree.Add(5);
            binTree.Add(2);
            binTree.Add(1);
            binTree.Add(4);
            binTree.Add(3);
            binTree.Add(6);
            binTree.PrintTree();
            Console.WriteLine(String.Join(" -> ",binTree.MaxPath()));
            Console.WriteLine(binTree.Contians(6));
            Console.WriteLine(binTree.Contians(9));
            binTree.Delete(2);
            binTree.PrintTree();
        }
    }
}
