
namespace Ogrenci_Ders_Linklist
{
    public class Node
    {
        public int OgrenciNo { get; private set; }
        public Dictionary<int, string> Derskodu_HarfOrt { get; private set; }
        public Node Next { get; internal set; }

        public Node(int ogrenciNo, Dictionary<int, string> derskodu_harfOrt)
        {
            OgrenciNo = ogrenciNo;
            Derskodu_HarfOrt = derskodu_harfOrt;
            Next = null;
        }
    }
    public class BagliList
    {
        private Node headNode;
        private Node tailNode;

        public BagliList()
        {
            headNode = null;
            tailNode = null;
        }

        public void OgrenciDersEkler(int orgNum, int dersNum, string harf)
        {
            //Eğer ögrenci varsa
            Node current = headNode;
            while (current != null)
            {
                if (current.OgrenciNo == orgNum)
                {
                    //Ögrenciye ders ekliyor(ders yoksa)
                    if (!current.Derskodu_HarfOrt.ContainsKey(dersNum))
                    {
                        current.Derskodu_HarfOrt.Add(dersNum, harf);
                        MessageBox.Show($"Ders {dersNum} öğrenci {orgNum} için eklendi!");
                    }
                    else
                    {
                        MessageBox.Show("Bu ders zaten öğrenciye kayıtlı!");
                    }
                    return;
                }
                current = current.Next;
            }

            //Eğer ögrenci yoksa
            var dict = new Dictionary<int, string>()
                {
                    { dersNum, harf }
                };
            Node newNode = new Node(orgNum, dict);
            newNode.Next = headNode;
            headNode = newNode;
            if (tailNode == null)
            {
                tailNode = newNode;
            }
            MessageBox.Show($"Yeni öğrenci {orgNum} ve ders {dersNum} eklendi!");

        }
        public void OgrenciDersSil(int orgNum, int dersNum)
        {
            if (headNode == null)
            {
                MessageBox.Show("List boştur");
                return;
            }
            //Eğer aranan ögrenci head'de
            if (headNode.OgrenciNo == orgNum)
            {
                if (headNode.Derskodu_HarfOrt.ContainsKey(dersNum))
                {
                    headNode.Derskodu_HarfOrt.Remove(dersNum);
                    MessageBox.Show("İşlem Başarılı");
                    //Ders olmayan ögrencileri silme
                    if (headNode.Derskodu_HarfOrt.Count == 0)
                    {
                        headNode = headNode.Next;
                        if (headNode == null)
                        {
                            tailNode = null;
                        }
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Ders bulunamadı!");
                    return;
                }
            }

            // Aranan öğrenciyi listede arama
            Node current = headNode;
            while (current.Next != null && current.Next.OgrenciNo != orgNum)
            {
                current = current.Next;
            }
            if (current.Next == null)
            {
                MessageBox.Show($"Ögrenci numara {orgNum} bulanmadı");
                return;
            }
            // It will make no sense starting from head because we tested it above
            Node current1 = current.Next;
            if (current1.Derskodu_HarfOrt.ContainsKey(dersNum))
            {
                current1.Derskodu_HarfOrt.Remove(dersNum);
                MessageBox.Show("İşlem Başarılı");
                // Eğer aranan ögrenci başka ders yoksa, silecek
                if (current1.Derskodu_HarfOrt.Count == 0)
                {
                    current.Next = current1.Next;
                    if (current1 == tailNode)
                    {
                        tailNode = current;
                    }
                }
            }
            else
            {
                MessageBox.Show("Ders bulunamadı!");
            }
        }
        public List<string> OgrenciDersListing(int orgNum = -1, int dersNum = -1)
        {
            List<string> sonucListesi = new List<string>();

            if (headNode == null)
            {
                MessageBox.Show("Liste boştur!");
                return sonucListesi;
            }
            Node current = headNode;
            if (orgNum != -1)
            {
                while (current != null && current.OgrenciNo != orgNum)
                {
                    current = current.Next;
                }
                if (current == null)
                {
                    MessageBox.Show($"Öğrenci numarası {orgNum} bulunamadı");
                    return sonucListesi;
                }
                foreach (var item in current.Derskodu_HarfOrt)
                {
                    sonucListesi.Add($"Ders: {item.Key}, Harf: {item.Value}");
                }
                return sonucListesi;
            }
            else if (dersNum != -1)
            {
                while (current != null)
                {
                    if (current.Derskodu_HarfOrt.ContainsKey(dersNum))
                    {
                        sonucListesi.Add(current.OgrenciNo.ToString());
                    }
                    current = current.Next;
                }
                if (sonucListesi.Count == 0)
                {
                    MessageBox.Show($"Ders kodu {dersNum} bulanmadı");
                }
                return sonucListesi;
            }
            else { return sonucListesi; }
        }
    }

}

