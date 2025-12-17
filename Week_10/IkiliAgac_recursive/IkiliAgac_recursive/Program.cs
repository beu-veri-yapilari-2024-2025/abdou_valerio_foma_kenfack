public class TreeNode
{
    public int Data;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int data)
    {
        Data = data;
    }
}
public class BinaryTree
{
    private TreeNode root;
    public BinaryTree()
    {
        root = null;
    }

    public void min()
    {
        TreeNode current = root;
        while (current.left != null)
        {
            current = current.left;
        }
        Console.WriteLine($"En küçük değer :{current.Data}");
    }
    public void max()
    {
        TreeNode current = root;
        while (current.right != null)
        {
            current = current.right;
        }
        Console.WriteLine($"En büyük değer :{current.Data}");
    }

    public void Add(int value)
    {
        root = AddRecursive(root,  value);
        Console.WriteLine($"{value} Başaralı eklendi");
    }
    private TreeNode AddRecursive(TreeNode node, int value)
    {
        if(node == null)
        {
            return new TreeNode(value);
        }
        else if(value < node.Data)
        {
            node.left = AddRecursive(node.left, value);
        }
        else if(value > node.Data)
        {
            node.right = AddRecursive(node.right, value);
        }
        return node;
    }
    public void silinme(int value)
    {
        bool silindi = false;
        root = silinmerecursive(root, value,ref silindi);
        if (silindi)
        {
            Console.WriteLine($"{value} Başaralı silindi");
        }
        else
        {
            Console.WriteLine($"{value} bulunamadi");
        }
    }
    private TreeNode silinmerecursive(TreeNode node, int value,ref bool silindi)
    {
        if (node == null)
        {    
            return null;
        }
        if (value < node.Data)
        {
            node.left = silinmerecursive(node.left, value, ref silindi);
        }
        else if (value > node.Data)
        {
            node.right = silinmerecursive(node.right, value, ref silindi);
        }
        else
        {
            silindi = true;
            if (node.left == null && node.right == null)
            {
                return null;
            }
            if (node.left == null)
            {
                return node.right;
            }
            if (node.right == null)
            {
                return node.left;
            }
            TreeNode succesor = minbulma(node.right);//#########################################
            node.Data = succesor.Data;
            node.right = silinmerecursive(node.right, succesor.Data,ref silindi);
            Console.WriteLine($"{value} Başaralı silindi");
        }
        return node;
    }
    private TreeNode minbulma(TreeNode node)
    {
        while(node.left != null)
        {
            node = node.left;
        }
        return node;
    }

    public void listeleme()
    {
        if (root == null)
        {
            Console.WriteLine("Agaç boştur");
            return;
        }

        Console.Write("Pre-order: ");
        preOrder(root);

        Console.Write("\nIn-order: ");
        inOrder(root);

        Console.Write("\nPost-order: ");
        postOrder(root);

        Console.Write("\nLevel-order: ");
        levelOrder();
        Console.WriteLine();
    }
    private void preOrder(TreeNode root)
    {
        if (root != null)
        {
            Console.Write($"{root.Data} ");
            preOrder(root.left);
            preOrder(root.right);
        }
    }
    private void inOrder(TreeNode root)
    {
        if (root != null)
        {
            inOrder(root.left);
            Console.Write($"{root.Data} ");
            inOrder(root.right);
        }
    }
    private void postOrder(TreeNode root)
    {
        if (root != null)
        {
            postOrder(root.left);
            postOrder(root.right);
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

            // Add children to the list
            if (current.left != null)
                nodes.Add(current.left);
            if (current.right != null)
                nodes.Add(current.right);

            i++;
        }
    }
    public void Arama(int value)
    {
        TreeNode sonuc = aramaRecursive(root,value);
        if(sonuc != null)
        {
            Console.WriteLine($"{value} agaçta bulundu");
        }
        else
        {
            Console.WriteLine($"{value} agaçta bulunmadi");
        }
    }
    private TreeNode aramaRecursive(TreeNode node, int value)
    {
        if (node == null)
        {
            return null;
        }
        if (node.Data == value)
        {
            return node;
        }
        else if(value < node.Data)
        {
            return aramaRecursive(node.left,value);
        }
        else
        {
            return aramaRecursive(node.right,value);
        }
    }
}
public class Program
{
    static void Main()
    {
        BinaryTree tree = new BinaryTree();
        tree.Add(6);
        tree.Add(3);
        tree.Add(15);
        tree.Add(20);
        tree.Add(7);
        tree.Add(16);
        tree.Add(17);
        bool bittimi = true;
        while (bittimi)
        {
            Console.Write("Ne yapmak istiyorsunuz?\n" +
                "1. Ağaca eklemek\n" +
                "2. Ağaçtan silmek\n" +
                "3. Ağaçtan en küçük değer\n" +
                "4. Ağaçtan en büyük değer\n"+
                "5. Ağaç listeleme\n"+
                "6. Ağaç Arama\n"+
                "7. Çikiş\n" +
                "Seçeninizi giren : ");
            string input = Console.ReadLine();
            
            switch (input)
            {
                case "1":
                    Console.Write("Bir sayi girin: ");
                    int value = int.Parse(Console.ReadLine());
                    tree.Add(value); break;
                case "2":
                    Console.Write("Silmek istediğiniz değer girin: ");
                    int value1 = int.Parse(Console.ReadLine());
                    tree.silinme(value1); break;
                case "3":
                    tree.min(); break;
                case "4":
                    tree.max(); break;
                case "5":
                    tree.listeleme(); break;
                case "6":
                    Console.Write("Hangi sayi bulmak istiyorsunuz: ");
                    int value2 = int.Parse(Console.ReadLine());
                    tree.Arama(value2); break;
                case "7":
                    Console.WriteLine("Çikiyor.........");
                    bittimi = false; break;
                default:
                    Console.WriteLine("Gecerli bir sayı girin!"); break;
            }
            Console.WriteLine();
        }
    }
}
