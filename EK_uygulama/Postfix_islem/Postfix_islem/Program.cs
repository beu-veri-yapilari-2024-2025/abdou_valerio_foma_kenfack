class ArrayStack
{
    private int[] S;
    private int top;
    private int kapasite;

    public ArrayStack(int kapasite)
    {
        this.kapasite = kapasite;
        S = new int[kapasite];
        top = -1;
    }
    public int gercekBoyut()
    {
        return top+1;
    }
    public bool bosmu()
    {
        return top == - 1;
    }
    public bool dolmu()
    {
        return top == kapasite - 1;
    }
    public int peek()
    {
        return S[top];
    }
    public void push(int x)
    {
        if (dolmu())
        {
            Console.WriteLine("Yigit doludur");
            return;
        }
        S[++top] = x;
    }
    public int pop()
    {
        if (bosmu())
        {
            return -1;
        }
        int kaldirilan = S[top];
        top--;
        return kaldirilan;
    }
}
class Program
{
    static void Main()
    {
        ArrayStack stack = new ArrayStack(50);
        Console.Write("Postfix girin: ");
        string postfix = Console.ReadLine();
        string signs = "/*-+^";
        for(int i = 0; i < postfix.Length; i++)
        {
           
            if (!signs.Contains(postfix[i]))
            {
                int token = int.Parse(postfix[i].ToString());
                stack.push(token);
            }
            else
            {
                int b = stack.pop();
                int a = stack.pop();
                if(a == -1 || b == -1)
                {
                    Console.WriteLine("Operand eksikligi var");
                    return;
                }
                int sonuc = islem(a, b, postfix[i]);
                stack.push(sonuc);
                //Console.WriteLine($"{a} {postfix[i]} {b} = {sonuc}");
            }   
        }
        if (stack.gercekBoyut() > 1)
        {
            //Console.WriteLine(stack.gercekBoyut());
            Console.WriteLine("Operator eksikligi var");
        }
        else
        {
            Console.WriteLine($"Sonuç : {stack.peek()}");
        }
    }
    static int islem(int x, int y,char sign)
    {
        if(sign == '+') { return x + y; }
        else if(sign == '-') { return x - y; }
        else if(sign == '*') { return x * y; }
        else {  return x / y; }
    }
}