using System.Drawing.Text;

namespace Ogrenci_Ders_Linklist
{
    public partial class Form1 : Form
    {
        private BagliList OgrenciDersListesi;
        public Form1()
        {
            OgrenciDersListesi = new BagliList();
            InitializeComponent();
            showMainMenu();

        }
        private void showMainMenu()
        {
            panelStuDersOperations.Visible = false;
        }

        private void buttonAddStudent_Click(object sender, EventArgs e)
        {
            listBox1.Visible = false;
            textBoxHarfOrt.Enabled = true;
            textBoxOrgNum.Enabled = true;
            textBoxDersKodu.Enabled = true;
            buttonDel.Visible = false;
            buttonQuery.Visible = false;
            buttonAdd.Visible = true;
            panelStuDersOperations.Visible = true;
        }

        private void buttonDelStu_Click(object sender, EventArgs e)
        {
            listBox1.Visible = false;
            textBoxHarfOrt.Enabled = false;
            textBoxOrgNum.Enabled = true;
            textBoxDersKodu.Enabled = true;
            buttonDel.Visible = true;
            buttonQuery.Visible = false;
            buttonAdd.Visible = false;
            panelStuDersOperations.Visible = true;
        }

        private void buttonStuListing_Click(object sender, EventArgs e)
        {
            listBox1.Visible = false;
            textBoxDersKodu.Enabled = true;
            textBoxOrgNum.Enabled = false;
            textBoxHarfOrt.Enabled = false;
            buttonDel.Visible = false;
            buttonQuery.Visible = true;
            buttonAdd.Visible = false;
            panelStuDersOperations.Visible = true;
        }

        private void buttonCourseListing_Click(object sender, EventArgs e)
        {
            listBox1.Visible = false;
            textBoxDersKodu.Enabled = false;
            textBoxOrgNum.Enabled = true;
            textBoxHarfOrt.Enabled = false;
            buttonDel.Visible = false;
            buttonQuery.Visible = true;
            buttonAdd.Visible = false;
            panelStuDersOperations.Visible = true;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            showMainMenu();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int orgNum;
            int derskodu;
            if (!int.TryParse(textBoxOrgNum.Text, out orgNum))
            {
                MessageBox.Show("Lütfen geçerli sayısal değerler girin!");
            }
            if (!int.TryParse(textBoxDersKodu.Text, out derskodu))
            {
                MessageBox.Show("Lütfen geçerli sayısal değerler girin!");
            }
            OgrenciDersListesi.OgrenciDersEkler(orgNum, derskodu, textBoxHarfOrt.Text);
            textBoxOrgNum.Clear();
            textBoxDersKodu.Clear();
            textBoxHarfOrt.Clear();

        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            int orgNum;
            int derskodu;
            if (!int.TryParse(textBoxOrgNum.Text, out orgNum))
            {
                MessageBox.Show("Lütfen geçerli sayısal değerler girin!");
            }
            if (!int.TryParse(textBoxDersKodu.Text, out derskodu))
            {
                MessageBox.Show("Lütfen geçerli sayısal değerler girin!");
            }
            OgrenciDersListesi.OgrenciDersSil(orgNum, derskodu);
            textBoxOrgNum.Clear();
            textBoxDersKodu.Clear();
        }

        private void buttonQuery_Click(object sender, EventArgs e)
        {
            listBox1.Visible = true;
            listBox1.Items.Clear();
            List<string> sonuclar = new List<string>(); ;

            if (textBoxOrgNum.Enabled && !string.IsNullOrEmpty(textBoxOrgNum.Text))
            {
                // Bir öğrenci için dersleri listeleyin
                int orgNum = int.Parse(textBoxOrgNum.Text);
                sonuclar = OgrenciDersListesi.OgrenciDersListing(orgNum: orgNum);
            }
            else if (textBoxDersKodu.Enabled && !string.IsNullOrEmpty(textBoxDersKodu.Text))
            {
                // Bir dersteki öğrencileri listeleyin
                int dersKodu = int.Parse(textBoxDersKodu.Text);
                sonuclar = OgrenciDersListesi.OgrenciDersListing(dersNum: dersKodu);
            }
            else
            {
                MessageBox.Show("Lütfen geçerli sayısal değerler girin!");
            }
            listBox1.Items.AddRange(sonuclar.ToArray());
        }
    }
}
