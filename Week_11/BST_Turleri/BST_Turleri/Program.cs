using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Xml;
using System.Xml.Linq;
namespace Types_BST
{
    public class TreeNode
    {
        public int Data;
        public int Height;
        public TreeNode Left;
        public TreeNode Right;
        public int Frequency;

        public TreeNode(int data)
        {
            Data = data;
            Height = 0;
            Frequency = 0;
        }
    }
    public class Tree
    {
        private TreeNode root;

        //************************COMMON FUNCTIONS****************************************
        public TreeNode RotateRight(TreeNode A)
        {
            TreeNode B = A.Left;
            TreeNode C = B.Right;

            B.Right = A;
            A.Left = C;

            A.Height = 1 + Math.Max(GetHeight(A.Left), GetHeight(A.Right));
            B.Height = 1 + Math.Max(GetHeight(B.Left), GetHeight(B.Right));

            return B;
        }
        public TreeNode RotateLeft(TreeNode A)
        {
            TreeNode B = A.Right;
            TreeNode C = B.Left;

            B.Left = A;
            A.Right = C;

            A.Height = 1 + Math.Max(GetHeight(A.Left), GetHeight(A.Right));
            B.Height = 1 + Math.Max(GetHeight(B.Left), GetHeight(B.Right));

            return B;
        }
        private int GetHeight(TreeNode node)
        {
            if (node == null)
            {
                return -1;
            }
            return node.Height;
        }

        // *******************AVL**************************************
        public void Insert(int value)
        {
            root = AVLInsert(root, value);
            Console.WriteLine($"{value} Başaralı eklendi");
        }
        private TreeNode AVLInsert(TreeNode node, int value)
        {
            if (node == null)
            {
                return new TreeNode(value);
            }
            else if (value < node.Data)
            {
                node.Left = AVLInsert(node.Left, value);
            }
            else if (value > node.Data)
            {
                node.Right = AVLInsert(node.Right, value);
            }
            else
            {
                return node;
            }
            // Getting the height of node which is longest subtree
            node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

            int balance = GetBalance(node);

            //LL
            if (balance > 1 && value < node.Left.Data)
            {
                return RotateRight(node);
            }
            //RR
            else if (balance < -1 && value > node.Right.Data)
            {
                return RotateLeft(node);
            }
            //LR
            else if (balance > 1 && value > node.Left.Data)
            {
                node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }
            //RL
            else if (balance < -1 && value < node.Right.Data)
            {
                node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }
            return node;
        }
        private int GetBalance(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }
            return GetHeight(node.Left) - GetHeight(node.Right);
        }
        public void yaz(string order)
        {
            if (root == null)
            {
                Console.WriteLine("Agaç boştur");
                return;
            }
            switch (order)
            {
                case "Pre-order":
                    preOrder(root); break;
                case "In-order":
                    inOrder(root); break;
                case "Post-order":
                    postOrder(root); break;
                case "Level-order":
                    levelOrder(); break;
            }
            Console.WriteLine();
        }
        private void preOrder(TreeNode root)
        {
            if (root != null)
            {
                Console.Write($"{root.Data} ");
                preOrder(root.Left);
                preOrder(root.Right);
            }
        }
        private void inOrder(TreeNode root)
        {
            if (root != null)
            {
                inOrder(root.Left);
                Console.Write($"{root.Data} ");
                inOrder(root.Right);
            }
        }
        private void postOrder(TreeNode root)
        {
            if (root != null)
            {
                postOrder(root.Left);
                postOrder(root.Right);
                Console.Write($"{root.Data} ");
            }
        }
        private void levelOrder()
        {
            var nodes = new List<TreeNode> { root };
            int i = 0;

            while (i < nodes.Count)
            {
                TreeNode current = nodes[i];
                Console.Write($"{current.Data} ");

                // Adding children to the list
                if (current.Left != null)
                {
                    nodes.Add(current.Left);
                }
                if (current.Right != null)
                {
                    nodes.Add(current.Right);
                }
                i++;
            }
        }
        //********************************** DSW ****************************************
        private TreeNode CreateBackbone()
        {
            TreeNode newRoot = new TreeNode('\0');
            newRoot.Right = root;
            TreeNode current = root;
            TreeNode parent = newRoot; // parent is the node before current

            while (current != null)
            {
                if (current.Left != null)
                {
                    parent.Right = RotateRight(current);
                    current = parent.Right; // To make sure the current node has no left child
                }
                else
                {
                    parent = current;
                    current = current.Right;
                }
            }
            return newRoot;
        }
        private int CountNodes()
        {
            int count = 0;
            TreeNode current = root;

            while (current != null)
            {
                count++;
                current = current.Right;
            }
            return count;
        }
        private void BalanceBackbone(int count)
        {
            TreeNode pseudoRoot = new TreeNode(0);
            pseudoRoot.Right = root;

            TreeNode parent = pseudoRoot;
            TreeNode current = root;

            for (int i = 0; i < count; i++)
            {
                TreeNode child = current.Right;
                parent.Right = RotateLeft(current);

                parent = parent.Right;
                current = parent.Right;
            }

            root = pseudoRoot.Right;
        }
        public void ApplyDSW()
        {
            root = CreateBackbone().Right;

            int n = CountNodes();
            //Number of nodes in the largest perfect tree
            int m = (int)Math.Pow(2, Math.Floor(Math.Log2(n + 1))) - 1;

            BalanceBackbone(n - m);

            while (m > 1)
            {
                m /= 2;
                BalanceBackbone(m);
            }
        }
        // *********************** Self-Adjusting Tree Fonksiyonları***************
        public void SearchWithFrequency(int value)
        {
            bool found = false;
            root = SearchAndAdjust(root, value, ref found);
            if (found)
            {
                Console.WriteLine($"{value} Ağaçta bulundu");
            }
            else
            {
                Console.WriteLine($"{value} Ağaçta bulunmadı");
            }
        }

        private TreeNode SearchAndAdjust(TreeNode node, int value, ref bool found)
        {
            if (node == null)
                return null;

            if (value < node.Data)
            {
                node.Left = SearchAndAdjust(node.Left, value, ref found);

                if (node.Left != null && node.Left.Frequency > node.Frequency)
                    node = RotateRight(node);
            }
            else if (value > node.Data)
            {
                node.Right = SearchAndAdjust(node.Right, value, ref found);

                if (node.Right != null && node.Right.Frequency > node.Frequency)
                    node = RotateLeft(node);
            }
            else
            {
                node.Frequency++;
                found = true;
            }

            return node;
        }



    }
    public class Program
    {
        static void Main()
        {
            Tree tree = new Tree();

            Console.WriteLine("=== INSERTING INTO AVL TREE ===");

            int[] values = { 30, 20, 10, 40, 50, 25, 45 };

            foreach (int v in values)
            {
                tree.Insert(v);
            }

            Console.WriteLine("=== FINAL AVL TREE ===");
            tree.yaz("In-order");
            tree.yaz("Pre-order");
            tree.yaz("Post-order");
            tree.yaz("Level-order");

            // ---------------- DSW ----------------
            Console.WriteLine("=== APPLYING DSW ===");
            tree.ApplyDSW();

            Console.WriteLine("DSW Balanced Tree (In-order)");
            tree.yaz("In-order");
            Console.WriteLine();

            // ---------------- SELF-ADJUSTING ----------------
            Console.WriteLine("=== SELF-ADJUSTING SEARCH ===");

            Console.WriteLine("Searching 45 (3 times)");
            tree.SearchWithFrequency(45);
            tree.SearchWithFrequency(45);
            tree.SearchWithFrequency(45);

            tree.yaz("Level-order");
            Console.WriteLine();

            Console.WriteLine("Searching 10 (2 times)");
            tree.SearchWithFrequency(10);
            tree.SearchWithFrequency(10);

            tree.yaz("Level-order");
            Console.WriteLine();
        }




    }
}