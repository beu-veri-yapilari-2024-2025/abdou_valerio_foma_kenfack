using System;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;

public class SortAlgorithm
{
    public int[] bubbleSort(int[] x)
    {
        int n = x.Length;
        int temp;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - 1 - i; j++)
            {
                if (x[j] > x[j + 1])
                {
                    temp = x[j];
                    x[j] = x[j + 1];
                    x[j + 1] = temp;
                }
            }

        }
        return x;
    }

    public void QuickSort(int[] input, int left, int right)
    {
        if (left < right)
        {
            int q = Partition(input, left, right);
            QuickSort(input, left, q - 1);
            QuickSort(input, q + 1, right);
        }
    }
    private static int Partition(int[] input, int left, int right)
    {
        int pivot = input[right];
        int temp;
        int i = left;
        for (int j = left; j < right; j++)
        {
            if (input[j] <= pivot)
            {
                temp = input[j];
                input[j] = input[i];
                input[i] = temp;
                i++;
            }
        }
        input[right] = input[i];
        input[i] = pivot;
        return i;
    }
    public int[] SelectionSort(int[] x, int n)
    {
        int temp;
        int min;

        for (int i = 0; i < n - 1; i++)
        {
            min = i;
            for (int j = i; j < n; j++)
            {
                if (x[j] < x[min])
                {
                    min = j;
                }
            }
            temp = x[i];
            x[i] = x[min];
            x[min] = temp;
        }
        return x;
    }
    public void InsertionSort(int[] x, int n)
    {
        int i, j, y;
        for (i = 0; i < n; i++)
        {
            y = x[i];
            for (j = i - 1; j >= 0 && y < x[j]; j--)
            {
                x[j + 1] = x[j];
            }
            x[j + 1] = y;
        }
    }
}
public class Program
{
    static void Main()
    {
        SortAlgorithm sort = new SortAlgorithm();
        int[] dizi = { 23, 398, 34, 100, 57, 67, 55, 320 };
        Console.Write("Sirasiz dizi : ");
        foreach (int i in dizi)
        {
            Console.Write($"{i} ");
        }

        bool bitir = false;
        while (!bitir)
        {
            dizi = [23, 398, 34, 100, 57, 67, 55, 320];
            Console.Write(
                          "\n1. Bubble sort" +
                          "\n2. Quick sort" +
                          "\n3. Selection sort" +
                          "\n4. Insertion sort" +
                          "\n5. Çikiş"+
                          "\nHangi siralama algoritma kullanmak istiyorsununz: ");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    int[] siralamaDizi = sort.bubbleSort(dizi);
                    Console.WriteLine("Bubble Sort");
                    foreach (int i in siralamaDizi)
                    {
                        Console.Write($"{i} ");
                    }
                    break;
                case "2":
                    sort.QuickSort(dizi, 0, dizi.Length - 1);
                    Console.WriteLine("\nQuick Sort");
                    foreach (int i in dizi)
                    {
                        Console.Write($"{i} ");
                    }
                    break;

                case "3":
                    siralamaDizi = sort.SelectionSort(dizi, dizi.Length);
                    Console.WriteLine("\nSelection Sort");
                    foreach (int i in siralamaDizi)
                    {
                        Console.Write($"{i} ");
                    }
                    break;
                case "4":
                    sort.InsertionSort(dizi, dizi.Length);
                    Console.WriteLine("\nInsertion Sort");
                    foreach (int i in dizi)
                    {
                        Console.Write($"{i} ");
                    }
                    break;
                case "5":
                    Console.WriteLine("Çıkıyor..................");
                    bitir = true; break;
                default:
                    Console.WriteLine("Geçerli bir sayi girin!"); break;

            }

        }
    }

}