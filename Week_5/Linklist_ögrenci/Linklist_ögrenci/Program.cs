using System.Collections.Generic;

class Program
{
    public class Node
    {
        public int Numara;
        public string Ad;
        public string Soyad;
        public Node Next;

        public Node(int numara, string ad, string soyad)
        {
            Numara = numara;
            Ad = ad;
            Soyad = soyad;
            Next = null;
        }

    }
    public class Baglilist
    {
        private Node head;
        private Node tail;

        public Baglilist()
        {
            head = null;
            tail = null;
        }
        // Başa eleman ekleme
        public void BasaEkle(int numara, string ad, string soyad)
        {
            Node newNode = new Node(numara,ad,soyad);
            newNode.Next = head;
            head = newNode;
            if (tail == null)  // list boşsa
            {
                tail = newNode;
            }
            Console.WriteLine($"{numara} numaralı öğrenci başa eklendi");
        }
        // Sona eleman ekleme
        public void sonaEkle(int numara, string ad, string soyad)
        {
            Node newNode = new Node(numara, ad, soyad); ;
            if (head == null)
            {
                head = newNode;
                tail = newNode;
                Console.WriteLine($"{numara} numaralı öğrenci sona eklendi");
                return;
            }
            tail.Next = newNode;
            tail = newNode;
            Console.WriteLine($"{numara} numaralı öğrenci sona eklendi");
        }
        // Belirli bir değerin sonrasına eleman ekleme
        public void sonrasinaEkle(int varolanDeger, int numara, string ad, string soyad)
        {
            Node current = head;
            // Listede varolanDeger'yi bulana kadar ilerle
            while (current != null && current.Numara != varolanDeger)
            {
                current = current.Next;
            }
            if (current == null)
            {
                Console.WriteLine($"{varolanDeger} listede bulumadı");
                return;
            }
            Node newNode = new Node(numara,ad,soyad);
            newNode.Next = current.Next;
            current.Next = newNode;
            Console.WriteLine($"{numara} numaralı öğrenci, {varolanDeger}'nin sonrasına eklendi");
        }
        // Ilk elemanı silmek
        public void bastanSil()
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş, silenecek eleman yok");
                return;
            }
            head = head.Next;
            Console.WriteLine("İlk eleman silindi");
            return;
        }
        // Son elemanı silmek
        public void sondanSil()
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş, silenecek eleman yok");
                return;
            }
            if (head.Next == null)
            {
                head = null;
                Console.WriteLine("Son eleman silindi");
                return;
            }
            Node current = head;
            while (current.Next.Next != null)
            {
                current = current.Next;
            }
            current.Next = null;
            tail = current;
            Console.WriteLine("Son eleman silindi");
            return;
        }
        // Belirli bir elemanı silme
        public void Remove(int numara)
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş, silenecek eleman yok");
                return;
            }
            if (head.Numara == numara)
            {
                head = head.Next;
                Console.WriteLine($"{numara} numaralı öğrenci listeden silindi");
                return;
            }
            Node current = head;
            while (current.Next != null && current.Next.Numara != numara)
            {
                current = current.Next;
            }
            if (current.Next == null)
            {
                Console.WriteLine($"{numara} numaralı öğrenci listede bulunmadı");
                return;
            }
            current.Next = current.Next.Next;
            Console.WriteLine($"{numara} numaralı öğrenci listeden silindi");
        }
        // Listeyi yazdırma
        public void Display()
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş, yazdıracak eleman yok");
                return;
            }
            Node current = head;
            Console.WriteLine("Liste: ");
            while (current != null)
            {
                Console.Write(current.Numara+", "+current.Ad+", "+current.Soyad+" " + " ---> ");
                current = current.Next;
            }
            Console.WriteLine();
        }
        // Eleman arama
        public void ara(int numara)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Numara == numara)
                {
                    Console.WriteLine($"{numara} listede bulunuyor");
                    return;
                }
                current = current.Next;
            }
            Console.WriteLine($"{numara} numaralı öğrenci listede bulunmuyor");
        }
    }
    public static (int, string, string) BilgiAl()
    {
        Console.Write("Ögrenci numarası girin: ");
        int kul_numara = int.Parse(Console.ReadLine());
        Console.Write("Ögrenci Ad girin: ");
        string kul_ad = Console.ReadLine();
        Console.Write("Ögrenci Soyad girin: ");
        string kul_soyad = Console.ReadLine();
        return (kul_numara, kul_ad, kul_soyad);
    }
    static void Main(string[] args)
    {
        Baglilist listim = new Baglilist();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n Linkedi ist İşlemleri");
            Console.WriteLine("1. Listeyi Göster");
            Console.WriteLine("2. Listenin başlangıca öğrenci bilgilerini ekleyin:");
            Console.WriteLine("3. Listenin sonuna öğrenci bilgilerini ekleyin:");
            Console.WriteLine("4. Belirli Bir Değerin Sonrasına Eleman Ekle");
            Console.WriteLine("5. İlk Elemanı Sil");
            Console.WriteLine("6. Son Elemanı Sil");
            Console.WriteLine("7. Ögrenci bilgisi Sil");
            Console.WriteLine("8. Ögrenci bilgisi Ara");
            Console.WriteLine("9. Çıkış");
            Console.Write("Bir işlem seçin (1-9): ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    listim.Display();
                    break;
                case "2":
                    var(kul_numara,kul_ad,kul_soyad) = BilgiAl();
                    listim.BasaEkle(kul_numara,kul_ad,kul_soyad); break;
                case "3":
                    var (kul_numara1, kul_ad1, kul_soyad1) = BilgiAl();
                    listim.sonaEkle(kul_numara1, kul_ad1, kul_soyad1); break;
                case "4":
                    Console.Write("Bir sonraki öğrenciyi eklemek istediğiniz öğrenci numarasını girin: ");
                    int varolanDeger = int.Parse(Console.ReadLine());
                    Console.Write("Yeni değeri girin: ");
                    var (kul_numara2, kul_ad2, kul_soyad3) = BilgiAl();
                    listim.sonrasinaEkle(varolanDeger, kul_numara2, kul_ad2, kul_soyad3); break;
                case "5":
                    listim.bastanSil(); break;
                case "6":
                    listim.sondanSil(); break;
                case "7":
                    Console.Write("Silinecek ögrenci, ögrenci numarası girin: ");
                    int removeValue = int.Parse(Console.ReadLine());
                    listim.Remove(removeValue); break;
                case "8":
                    Console.Write("Aranack ögrenci, ögrenci numarası girin:: ");
                    int DegerAra = int.Parse(Console.ReadLine());
                    listim.ara(DegerAra); break;
                case "9":
                    running = false;
                    Console.WriteLine("Çikiyor...."); break;
            }
        }
    }
}