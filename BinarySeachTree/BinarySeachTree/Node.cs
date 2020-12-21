namespace BinarySeachTree
{
    public class Node
    {
        public int key;
        public int height;
        public Node left;
        public Node right;

        public Node(int k)
        {
            key = k;
            left = right = null;
            height = 1;
        }

    }
}