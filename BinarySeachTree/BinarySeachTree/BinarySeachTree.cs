namespace BinarySeachTree
{
    public class BinarySeachTree
    {

        private Node root = null;
        
        private int Height(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            return node.height;
        }

        private int BFactor(Node node)
        {
            return Height(node.right) - Height(node.left);
        }

        private void FixHeight(Node node)
        {
            int hl = Height(node.left);
            int hr = Height(node.right);
            node.height = (hl > hr ? hl : hr) + 1;
        }

        private Node RotateRight(Node p)
        {
            Node q = p.left;
            p.left = q.right;
            q.right = p;
            FixHeight(p);
            FixHeight(q);
            return q;
        }

        private Node RotateLeft(Node q)
        {
            Node p = q.right;
            q.right = p.left;
            p.left = q;
            FixHeight(q);
            FixHeight(p);
            return p;
        }

        private Node Balance(Node p)
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

        private Node Insert(Node p, int key)
        {
            if (p == null)
            {
                return new Node(key);
            }

            if (key < p.key)
            {
                p.left = Insert(p.left, key);
            }
            else
            {
                p.right = Insert(p.right, key);
            }

            return Balance(p);
        }

        public void Insert(int key)
        {
            root = Insert(root, key);
        }

        private Node FindMin(Node p)
        {
            return p.left != null ? FindMin(p.left) : p;
        }

        private Node RemoveMin(Node p)
        {
            if (p.left == null)
            {
                return p.right;
            }

            p.left = RemoveMin(p.left);

            return Balance(p);
        }

        private Node Remove(Node p, int key)
        {
            if (p == null)
            {
                return null;
            }

            if (key < p.key)
            {
                p.left = Remove(p.left, key);
            }
            else if (key > p.key)
            {
                p.right = Remove(p.right, key);
            }
            else
            {
                Node l = p.left;
                Node r = p.right;
                if (r == null)
                {
                    return l;
                }

                Node min = FindMin(r);
                min.right = RemoveMin(r);
                min.left = l;
                return Balance(min);
            }

            return Balance(p);
        }

        public void Remove(int key)
        {
            root = Remove(root, key);
        }
        
    }
}