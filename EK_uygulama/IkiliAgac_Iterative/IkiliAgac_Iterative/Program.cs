public class TreeNode
{
    public int Data;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int data)
    {
        Data = data;
        left = null;
        right = null;
    }
}
public class BinaryTree
{
    private TreeNode root;

    public BinaryTree()
    {
        root = null;
    }
    public void Inserstion_iterative(int value)
    {
        TreeNode newNode = new TreeNode(value);
        if (root == null)
        {
            root = newNode;
            Console.WriteLine($"{value} Başarılı eklendi");
            return;
        }
        TreeNode current = root;
        while (current != null)
        {
            if (value < current.Data)
            {
                if (current.left == null)
                {
                    current.left = newNode;
                    Console.WriteLine($"{value} Başarılı eklendi");
                    break;
                }
                current = current.left;

            }
            else if (value > current.Data)
            {
                if (current.right == null)
                {
                    current.right = newNode;
                    Console.WriteLine($"{value} Başarılı eklendi");
                    break;
                }
                current = current.right;
            }
            else
            {
                Console.WriteLine($"{value} zaten ağaçta");
                break;
            }
        }
    }
    // Simple in-order traversal to display the tree
    public void yaz()
    {
        Console.Write("Tree elements: ");
        DisplayRecursive(root);
        Console.WriteLine();
    }
    private void DisplayRecursive(TreeNode node)
    {
        if (node != null)
        {
            DisplayRecursive(node.left);
            Console.Write($"{node.Data} ");
            DisplayRecursive(node.right);
        }
    }
    public void Arama(int value)
    {
        if (root == null)
        {
            Console.WriteLine("Agaç boştur");
            return;
        }
        TreeNode current = root;
        while (current != null)
        {
            if (current.Data == value)
            {
                Console.WriteLine($"{value} agaçta bulundu");
                return;
            }
            else if (value < current.Data)
            {
                current = current.left;
            }
            else
            {
                current = current.right;
            }
        }
        Console.WriteLine($"{value} agaçta bulunmadi");
    }
}
public class program
{
    static void Main()
    {
        BinaryTree ikiliAgac = new BinaryTree();
        ikiliAgac.Inserstion_iterative(12);
        ikiliAgac.Inserstion_iterative(45);
        ikiliAgac.Inserstion_iterative(6);
        ikiliAgac.Inserstion_iterative(30);
        ikiliAgac.Inserstion_iterative(10);
        ikiliAgac.Inserstion_iterative(6);
        ikiliAgac.yaz();
        ikiliAgac.Arama(12);
        ikiliAgac.Arama(58);

    }
}