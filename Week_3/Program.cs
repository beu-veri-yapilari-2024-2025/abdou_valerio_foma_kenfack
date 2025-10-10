class Program
{
    static int DiziToplami(int[] dizi){
        int toplam = 0;
        for(int i = 0; i < dizi.Length; i++){
            toplam += dizi[i];
        }
        return toplam;
    }
    static int ikiliArama(int[] dizi, int sayi)
    {
        int uzunluk = dizi.Length;
        int sol = 0;
        int sag = uzunluk - 1;

        while (sol <= sag)
        {
            int ort = (sol + sag) / 2;
            if (dizi[ort] == sayi)
            {
                return ort;
            }
            else if (sayi < dizi[ort])
            {
                sag = ort - 1;
            }
            else
            {
                sol = ort + 1;
            }
        }
        return -1;
    }

        static int[,] MatrisCarpim(int[,] matris1, int[,] matris2)
        {
            int satir = matris1.GetLength(0);
            int sutun = matris2.GetLength(1);
            int[,] sonuc_matris = new int[satir,sutun];
            for(int i = 0; i < satir; i++)
            {
                for(int j = 0; j < sutun; j++)
                {
                    int toplam = 0;
                    for (int k=0; k<matris2.GetLength(0); k++)
                    {
                        toplam += matris1[i, k] * matris2[k, j];
                    }
                    sonuc_matris[i, j] = toplam;
                }
            }
            return sonuc_matris;
        }

    static void Main()
    {
        int[] dizi = { 12, 15, 20, 30, 35, 64, 73, 80 };
        int aranan_sayısı = 64;
        int index = ikiliArama(dizi, aranan_sayısı);
        Console.WriteLine("{0} sayısı {1} indeksindedir",aranan_sayısı,index);
        Console.WriteLine();

        int dizi_toplam = DiziToplami(dizi);
        Console.WriteLine("Listedeki elemanların toplamı: " + Convert.ToString(dizi_toplam));
        Console.WriteLine();

        int[,] matris1 = { { 1, 2 }, { 3, 4 } };
        int[,] matris2 = { { 5, 2 }, { 3, 0 } };
        int[,] sonuc = MatrisCarpim(matris1, matris2);
        for (int i = 0; i < sonuc.GetLength(0); i++)
        {
            for(int j = 0; j < sonuc.GetLength(1); j++)
            {
                Console.Write(sonuc[i,j].ToString() + " ");
            }
            Console.WriteLine();        }
    }
    
}   