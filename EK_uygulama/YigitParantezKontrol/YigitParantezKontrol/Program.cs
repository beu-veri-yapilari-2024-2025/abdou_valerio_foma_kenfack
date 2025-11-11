using System.Runtime.InteropServices;
using static Node;

public class Node
{
    private char data;
    private Node Next;

    public Node(char data)
    {
        this.data = data;
        Next = null;
    }
    public class Yigit
    {
        Node top;

        public Yigit()
        {
            top = null;
        }
        public void push(char item)
        {
            Node newNode = new Node(item);
            newNode.Next = top;
            top = newNode;
        }
        public char pop()
        {
            if (IsEmty())
            {
                return '\0'; // \0 means null in char
            }
            char value = top.data;
            top = top.Next;
            return value;
        }
        public bool IsEmty()
        {
            return top == null;
        }
    }
}
public class Program
{
    static void Main()
    {
        Yigit yigit = new Yigit();
        string open = "{[(";
        string close = ")]}";

        Console.Write("Enter Your Brackets: ");
        string parantezler = Console.ReadLine();

        foreach (char sembol in parantezler)
        {
            if (open.Contains(sembol))
            {
                yigit.push(sembol);
            }
            else if(close.Contains(sembol))
            {
                if (yigit.IsEmty())
                {
                    Console.WriteLine("Acıkış çiftleri eksik");
                    return;
                }
                char value = yigit.pop();

                if ( !( (value == '(' && sembol == ')') ||
                       (value == '[' && sembol == ']') ||
                       (value == '{' && sembol == '}') ) )
                {
                    Console.WriteLine($"{value} parantezinin kapanış çifti yok");
                    return;
                }
 
            }
        }
        if (yigit.IsEmty())
        {
            Console.WriteLine("Bütün parantezler tamamlandı");
        }
        else
        {
            Console.WriteLine("Kapanış çiftleri eksik");
        }
    }
}