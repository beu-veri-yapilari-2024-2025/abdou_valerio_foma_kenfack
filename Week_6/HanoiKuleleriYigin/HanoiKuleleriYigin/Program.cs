﻿class hanoiKuleriYigin
{
    public static void Hanoi(int n, char start, char end, char auxilary)
    {
        if(n == 1)
        {
            Console.WriteLine($"{start} --> {end}");
            return;
        }
        else
        {
            Hanoi(n - 1, start, auxilary, end);
            Console.WriteLine($"{start} --> {end}");
            Hanoi(n - 1, auxilary, end, start);
        }
    }
    static void Main()
    {
        Console.Write("n degerini giriniz: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Aşağıda A kulesinden C kulesine geçmek için gereken tüm adımlar yer almaktadır");
        Hanoi(n, 'A', 'C', 'B');
    }
}