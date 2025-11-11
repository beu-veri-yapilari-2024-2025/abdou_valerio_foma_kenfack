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
            if (IsEmpty())
            {
                return '\0'; // \0 means null in char
            }
            char value = top.data;
            top = top.Next;
            return value;
        }
        public bool IsEmpty()
        {
            return top == null;
        }
        public char peek()
        {
            if (IsEmpty())
            {
                return '\0'; // \0 means null in char
            }
            return top.data;
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
        string operators = "^*/+-";
        List<char> sonucu = new List<char>();
        Console.Write("Enter the infix notation: ");
        string parantezler = Console.ReadLine();
        // Add at the beginning
        char[] charArray = parantezler.ToCharArray();
        Array.Reverse(charArray);
        string reversedInput = new string(charArray);
        foreach(var item in reversedInput) { Console.Write(item); }

        foreach (char sembol in parantezler)
        {
            if (open.Contains(sembol))
            {
                yigit.push(sembol);
            }
            else if (operators.Contains(sembol))
            {
                while (!yigit.IsEmpty() &&
                       operators.Contains(yigit.peek()) &&
                       priority(yigit.peek()) >= priority(sembol))
                {
                    sonucu.Add(yigit.pop());
                }
                yigit.push(sembol);
            }
            else if (close.Contains(sembol))
            {
                if (yigit.IsEmpty())
                {
                    Console.WriteLine("Yiğit boştur");
                    return;
                }
                while (true)
                {
                    char value = yigit.pop();
                    if (open.Contains(value)) { break; }
                    sonucu.Add(value);
                }
            }
            else
            {
                sonucu.Add(sembol);
            }
        }
        while (!yigit.IsEmpty())
        {
            sonucu.Add(yigit.pop());
        }
        for (int i = 0; i < sonucu.Count; i++)
        {
            Console.Write(sonucu[i]);
        }
    }
    public static int priority(char sembol)
    {
        if(sembol == '^') { return 3; }
        else if(sembol == '*' || sembol == '/') {  return 2; }
        else{return 1; }//for + or -
    }
}