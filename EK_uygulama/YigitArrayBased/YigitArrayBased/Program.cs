using static System.Runtime.InteropServices.JavaScript.JSType;

public class Yigit
{
    int kapasite = 100;
    int[] s;
    int p;

    public Yigit()
    {
        s = new int[kapasite];
        p = 0;
    }
    public bool IsEmpty()
    {
        if(p < 1)
        {
            return true;
        }
        return false;
    }
    public bool dolMu()
    {
        if (p == kapasite - 1)
        {
            return true;
        }
        return false;
    }
    public void push(int item)
    {
        if (dolMu())
        {
            Console.WriteLine("Stack Overflow");
            return;
        }
        s[p] = item;
        p++;
        Console.WriteLine($"{item} yığına başarılı eklendi");
    }
    public void pop()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Stack underflow");
            return;
        }
        int id = p - 1;
        p--;
        Console.WriteLine($"{s[id]} başarılı çıkardı");
    }
    public void peek()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Stack underflow");
            return;
        }
        Console.WriteLine($"Üst eleman : {s[p-1]}");
    }
    public void yazdir()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Stack underflow");
            return;
        }
        for (int i = p-1; i >=0; i--)
        {
            Console.WriteLine(s[i]);
        }
    }
    static void Main()
    {
        Yigit yigit = new Yigit();
        bool biter = false;
        while (!biter)
        {
            Console.WriteLine("1. Yığına eleman eklemek");
            Console.WriteLine("2. Yığınından eleman çıkarmak");
            Console.WriteLine("3. Üst eleman");
            Console.WriteLine("4. Yığın yazdır");
            Console.WriteLine("5. Çıkış");
            Console.Write("Seçiniz gırın: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Write("Eklemek istediği eleman girin: ");
                    int elemanEk = int.Parse(Console.ReadLine());
                    yigit.push(elemanEk); break;
                case "2":
                    yigit.pop(); break;
                case "3":
                    yigit.peek(); break;
                case "4":
                    yigit.yazdir(); break;
                case "5":
                    biter = true;
                    Console.WriteLine("Çıkıyor.......");
                    break;
            }
            Console.WriteLine("******************************");
        }
    }
}