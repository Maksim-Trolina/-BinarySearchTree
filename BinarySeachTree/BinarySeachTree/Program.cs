using System;

namespace BinarySeachTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySeachTree<string> binarySeachTree = new BinarySeachTree<string>();

            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int key = Convert.ToInt32(Console.ReadLine());
                binarySeachTree.Insert(key,Console.ReadLine());
            }

            int m = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                int key = Convert.ToInt32(Console.ReadLine());
                
                binarySeachTree.Remove(key);
            }

            int d = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < d; i++)
            {
                int key = Convert.ToInt32(Console.ReadLine());
                
                Console.WriteLine(binarySeachTree.Contains(key));
            }
        }
    }
}