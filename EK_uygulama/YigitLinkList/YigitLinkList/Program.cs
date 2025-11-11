class Node
{
    public int Veri;
    public Node sonraki;

    public Node(int veri)
    {
        Veri = veri;
        sonraki = null;
    }
    class YigitLinkList
    {
        Node top = null;
        
        public void Push(int veri)
        {
            Node yeni = new Node(veri);
            yeni.sonraki = top;
            top = yeni;
            Console.WriteLine($"{veri} yığına eklendi");
        }
        public void Pop()
        {
            if(top == null)
            {
                Console.WriteLine("Yığın boş");
                return;
            }
            Console.WriteLine($"{top.Veri} yığına çıkarıldı");
            top = top.sonraki;

        }
        public void Peek()
        {
            if (top == null)
            {
                Console.WriteLine("Yığın boş");
                return;
            }
            Console.WriteLine($"Yığının tepesindeki eleman: {top.Veri}");
        }
        public void Yazdir()
        {
            Console.WriteLine("Yığın içeriği: ");
            Node temp = top;
            while(temp != null)
            {
                Console.WriteLine(temp.Veri);
                temp = temp.sonraki;
            }
        }
    }
    static void Main()
    {
        YigitLinkList yigit = new YigitLinkList();
        bool biter = false;
        while (!biter)
        {
            Console.WriteLine("1. Yığına eleman eklemek");
            Console.WriteLine("2. Yığınından eleman çıkarmak");
            Console.WriteLine("3. Yığın yazdırmak");
            Console.WriteLine("4. Üst eleman");
            Console.WriteLine("5. Çıkış");
            Console.Write("Seçiniz gırın: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Write("Eklemek istediği eleman girin: ");
                    int elemanEk = int.Parse(Console.ReadLine());
                    yigit.Push(elemanEk); break;
                case "2":
                    yigit.Pop(); break;
                case "3":
                    yigit.Yazdir(); break;
                case "4":
                    yigit.Peek(); break;
                case "5":
                    biter = true;
                    Console.WriteLine("Çıkıyor.......");
                      break;
            }
            Console.WriteLine("******************************");
        }
    }
}