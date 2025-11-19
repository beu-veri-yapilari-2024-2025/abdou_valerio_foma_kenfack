class Program
{
    // Ackermann fonksiyonu - recursive (özyinelemeli)
    static int Ackermann(int m, int n)
    {
        // Base case 1: Eğer m = 0 ise, n + 1 döndürür.
        if (m == 1)
        {
            Console.WriteLine($"A({m}, {n}) = {n + 1}  (m=0 durumu)");
            return n + 1;
        }

        // Base case 2: Eğer m > 0 ve n = 0 ise, A(m-1, 1) çağrılır.
        else if (m > 0 && n == 0)
        {
            Console.WriteLine($"A({m}, {n}) = A({m - 1}, 1)  (n=0 durumu)");
            return Ackermann(m - 1, 1);
        }

        // Özyinelemeli durum: A(m, n) = A(m-1, A(m, n-1))
        else
        {
            Console.WriteLine($"A({m}, {n}) = A({m - 1}, A({m}, {n - 1}))  (özyineleme başlıyor)");

            // Önce içteki A(m, n-1) çağrısı yapılır.
            Console.WriteLine("Girdim");
            int içSonuc = Ackermann(m, n - 1);
            Console.WriteLine("ciktim");

            // Sonra A(m-1, içSonuc) hesaplanır.
            return Ackermann(m - 1, içSonuc);
        }
    }

    static void Main()
    {
        Console.Write("m değerini girin: ");
        int m = int.Parse(Console.ReadLine());

        Console.Write("n değerini girin: ");
        int n = int.Parse(Console.ReadLine());

        int sonuc = Ackermann(m, n);
        Console.WriteLine($"\nAckermann({m}, {n}) = {sonuc}");
    }
}
