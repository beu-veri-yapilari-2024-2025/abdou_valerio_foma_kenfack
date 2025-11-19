public class Hashing
{
    Random rand = new Random();
    int[] anahtarDeger;
    int[] hashTablosu;
    int index;
    public Hashing()
    {
        anahtarDeger = new int[100];
        hashTablosu = new int[100];
        index = -1;
       /* for (int i = 0;i< anahtarDeger.Length; i++)
        {
            anahtarDeger[i] = rand.Next(1, 100);
        }*/
    }
    public void HashFonk()
    {
        for (int i = 0;i < anahtarDeger.Length; i++)
        {
            anahtarDeger[i] = rand.Next(1, 100);
            index = anahtarDeger[i] % hashTablosu.Length;
            if (hashTablosu[index] == 0)
            {
                hashTablosu[index] = anahtarDeger[i];
            }
            else
            {
                Console.Write($"\nÇakışma vardır HashTablosu[{index}] = {hashTablosu[index]} Yeni deger {anahtarDeger[i]}\n" +
                    "1.Linear Probing\n" +
                    "2.Quadratic Probing\n" +
                    "Hangi çakışmanın giderilmesi kullanmak istiyorsunuz : ");
                int input = int.Parse(Console.ReadLine());
                if(input == 1)
                {
                    index = LinearProbing(index);
                }
                else
                {
                   index =  QuadraticProbing(index);
                }
                hashTablosu[index] = anahtarDeger[i];
            }
            Console.WriteLine($"HashTablosu[{index}] = {anahtarDeger[i]}");
        }
    }
    public int LinearProbing(int index)
    {
        while(hashTablosu[index] != 0)
        {
            index++;
            if (index == hashTablosu.Length) { index = 0; }
        }
        return index;

    }
    public int QuadraticProbing(int index)
    {
        int x = 0;
        int current = index;
        while (hashTablosu[current] != 0)
        {
            x++;
            current++;
            if (current == hashTablosu.Length) { current = 0; }
        }
        index = index + (x * x);
        if (index >= hashTablosu.Length)
        {
            index = index%hashTablosu.Length ;
        }
        return index;
    }
}
public class Program
{
    static void Main()
    {
        Hashing hashing = new Hashing();
        hashing.HashFonk();
    }
}