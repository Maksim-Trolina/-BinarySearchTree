namespace BinarySeachTree
{
    public class BinarySeachTree
    {
        public int Height(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            return node.height;
        }

        public int BFactor(Node node)
        {
            return Height(node.right) - Height(node.left);
        }

        public void FixHeight(Node node)
        {
            int hl = Height(node.left);
            int hr = Height(node.right);
            node.height = (hl > hr ? hl : hr) + 1;
        }

        public Node RotateRight(Node p)
        {
            Node q = p.left;
            p.left = q.right;
            q.right = p;
            FixHeight(p);
            FixHeight(q);
            return q;
        }

        public Node RotateLeft(Node q)
        {
            Node p = q.right;
            q.right = p.left;
            p.left = q;
            FixHeight(q);
            FixHeight(p);
            return p;
        }

        public Node Balance(Node p)
        {
            FixHeight(p);
            if (BFactor(p) == 2)
            {
                if (BFactor(p.right) < 0)
                {
                    p.right = RotateRight(p.right);
                }
                return RotateLeft(p);
            }

            if (BFactor(p) == -2)
            {
                if (BFactor(p.left) > 0)
                {
                    p.left = RotateLeft(p.left);
                }

                return RotateRight(p);
            }

            return p;
        }
    }
}