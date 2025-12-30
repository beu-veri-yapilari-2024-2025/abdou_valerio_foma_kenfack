public class kutuphane
{
    public string KitapAdi {  get; set; }
    public int basimYil {  get; set; }
    public kutuphane(string KitapAdi,int basimYil)
    {
        this.KitapAdi = KitapAdi;
        this.basimYil = basimYil;
    }
}
public class mergeSortUygulama
{
    public void mergeSort(kutuphane[] kitap, int sol, int sag)
    {
        if(sol < sag)
        {
            int ort = sol + (sag - sol) / 2;

            // 1 parca
            mergeSort(kitap, sol, ort);

            // 2 parca
            mergeSort(kitap, ort+1, sag);

            merge(kitap, sol, ort, sag);
        }
    }
    private void merge(kutuphane[] kitap, int sol, int ort, int sag)
    {
        int solBoyut = ort - sol + 1;
        int sagBoyut = sag - ort;
        kutuphane[] solArray = new kutuphane[solBoyut];
        kutuphane[] sagArray = new kutuphane[sagBoyut];

        for(int i = 0; i < solBoyut; i++)
        {
            solArray[i] = kitap[sol + i];
        }
        for(int j  = 0; j < sagBoyut; j++)
        {
            sagArray[j] = kitap[ort + j +1];
        }
        int l = 0, r = 0, k = sol;
        while (l < solBoyut &&  r < sagBoyut)
        {
            if(solArray[l].basimYil <= sagArray[r].basimYil)
            {
                kitap[k] = solArray[l];
                l++;
                k++;
            }
            else
            {
                kitap[k] = sagArray[r];
                r++;
                k++;
            }
        }
        while(l < solBoyut)
        {
            kitap[k] = solArray[l];
            l++;
            k++;
        }
        while (r < sagBoyut)
        {
            kitap[k] = sagArray[r];
            r++;
            k++;
        }
    }
    public void yaz(kutuphane[] array)
    {
        foreach(var kitap in array)
        {
            Console.WriteLine ($"{kitap.KitapAdi} : {kitap.basimYil};   ");
        }
    }
}
public class Program
{
    static void Main()
    {
        kutuphane[] kitaplar =
        {
            new kutuphane("Kürk mantolu Madonna",1943),
            new kutuphane("Kar",2005),
            new kutuphane("Benim Adım Kırmızı", 1998),
            new kutuphane("Aşkın Kırk Kuralı", 2000),
            new kutuphane("Zaman Düzenleme Enstitüsü", 1954)
        };
        mergeSortUygulama islemci = new mergeSortUygulama();
        Console.WriteLine("Siralama önce");
        islemci.yaz(kitaplar);
        islemci.mergeSort(kitaplar, 0, kitaplar.Length-1);
        Console.WriteLine("\nSiralama sonra");
        islemci.yaz(kitaplar);

    }
}