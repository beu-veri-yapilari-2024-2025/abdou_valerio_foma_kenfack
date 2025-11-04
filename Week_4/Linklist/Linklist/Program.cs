using System.Collections.Generic;

class Program
{
    public class Node
    {
        public int Data;
        public Node Next;

    public Node(int data)
        {
            Data = data;
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
        public void BasaEkle(int value)
        {
            Node newNode = new Node(value);
            newNode.Next = head;
            head = newNode;
            Console.WriteLine($"{value} başa eklendi");
            if (tail == null)  // list boşsa
            {
                tail = newNode;
            }
            Console.WriteLine($"{value} başa eklendi");
        }
        // Sona eleman ekleme
        public void sonaEkle(int value)
        {
            Node newNode = new Node(value);
            if(head == null)
            {
                head = newNode;
                tail = newNode;
                Console.WriteLine($"{value} sona eklendi");
                return;
            }
            tail.Next = newNode;
            tail = newNode;
            Console.WriteLine($"{value} sona eklendi");
        }
        // Belirli bir değerin sonrasına eleman ekleme
        public void sonrasinaEkle(int varolanDeger, int yeniDeger)
        {
            Node current = head;
            // Listede varolanDeger'yi bulana kadar ilerle
            while (current != null && current.Data != varolanDeger)
            {
                current = current.Next;
            }
            if(current == null)
            {
                Console.WriteLine($"{varolanDeger} listede bulumadı");
                return;
            }
            Node newNode = new Node(yeniDeger);
            newNode.Next = current.Next;
            current.Next = newNode;
            Console.WriteLine($"{yeniDeger}, {varolanDeger}'nin sonrasına eklendi");
        }
        // Ilk elemanı silmek
        public void bastanSil()
        {
            if(head == null)
            {
                Console.WriteLine("Liste boş, silenecek eleman yok");
                return;
            }
            head = head.Next;
            Console.WriteLine("İlk eleman silindi");
            return ;
        }
        // Son elemanı silmek
        public void sondanSil()
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş, silenecek eleman yok");
                return;
            }
            if(head.Next == null)
            {
                head = null;
                Console.WriteLine("Son eleman silindi");
                return;
            }
            Node current = head;
            while(current.Next.Next != null)
            {
                current = current.Next;
            }
            current.Next = null;
            tail = current;
            Console.WriteLine("Son eleman silindi");
            return;
        }
        // Belirli bir elemanı silme
        public void Remove(int value)
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş, silenecek eleman yok");
                return;
            }
            if(head.Data == value)
            {
                head = head.Next;
                Console.WriteLine($"{value} listeden silindi");
                return;
            }
            Node current = head;
            while(current.Next != null && current.Next.Data != value)
            {
                current = current.Next;
            }
            if(current.Next == null)
            {
                Console.WriteLine($"{value} listede bulunmadı");
                return;
            }
            current.Next = current.Next.Next;
            Console.WriteLine($"{value} listeden silindi");
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
                Console.Write(current.Data + "-->");
                current = current.Next;
            }
            Console.WriteLine();
        }
        // Eleman arama
        public void ara(int value)
        {
            Node current = head;
            while (current != null)
            {
                if(current.Data == value)
                {
                    Console.WriteLine($"{value} listede bulunuyor");
                    return;
                }
                current = current.Next;
            }
            Console.WriteLine($"{value} listede bulunmuyor");
        }
    }
    static void Main(string[] args)
    {
        Baglilist listim = new Baglilist();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n Linkedi ist İşlemleri");
            Console.WriteLine("1. Listeyi Göster");
            Console.WriteLine("2. Başa Eleman Ekle");
            Console.WriteLine("3. Sona Eleman Ekle");
            Console.WriteLine("4. Belirli Bir Değerin Sonrasına Eleman Ekle");
            Console.WriteLine("5. İlk Elemanı Sil");
            Console.WriteLine("6. Son Elemanı Sil");
            Console.WriteLine("7. Eleman Sil");
            Console.WriteLine("8. Eleman Ara");
            Console.WriteLine("9. Çıkış");
            Console.Write("Bir işlem seçin (1-9): ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    listim.Display();
                    break;
                case "2":
                    Console.Write("Başa ekleneck değeri girin: ");
                    int BasaEkleValue = int.Parse(Console.ReadLine());
                    listim.BasaEkle(BasaEkleValue); break;
                case "3":
                    Console.Write("Sona ekleneck değeri girin: ");
                    int DegeriSonaEkler = int.Parse(Console.ReadLine());
                    listim.sonaEkle(DegeriSonaEkler); break;
                case "4":
                    Console.Write("Sonrasına eklemek istediğiniz değeri girin: ");
                    int varolanDeger = int.Parse(Console.ReadLine());
                    Console.Write("Yeni değeri girin: ");
                    int yeniDeger = int.Parse(Console.ReadLine());
                    listim.sonrasinaEkle(varolanDeger, yeniDeger); break;
                case "5":
                    listim.bastanSil(); break;
                case "6":
                    listim.sondanSil(); break;
                case "7":
                    Console.Write("Silinecek elemanı girin: ");
                    int removeValue = int.Parse(Console.ReadLine());
                    listim.Remove(removeValue); break;
                case "8":
                    Console.Write("Aranacak elemanı girin: ");
                    int DegerAra = int.Parse(Console.ReadLine());
                    listim.ara(DegerAra); break;
                case "9":
                    running = false;
                    Console.WriteLine("Çikiyor...."); break;
            }
        }
    }
}