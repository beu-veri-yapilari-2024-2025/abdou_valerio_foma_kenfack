namespace Ogrenci_Ders_Linklist
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelMainMenu = new Panel();
            panelStuDersOperations = new Panel();
            buttonQuery = new Button();
            buttonBack = new Button();
            buttonDel = new Button();
            buttonAdd = new Button();
            textBoxDersKodu = new TextBox();
            textBoxHarfOrt = new TextBox();
            textBoxOrgNum = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            buttonCourseListing = new Button();
            buttonStuListing = new Button();
            buttonDelStu = new Button();
            buttonAddStudent = new Button();
            label2 = new Label();
            listBox1 = new ListBox();
            panelMainMenu.SuspendLayout();
            panelStuDersOperations.SuspendLayout();
            SuspendLayout();
            // 
            // panelMainMenu
            // 
            panelMainMenu.Controls.Add(panelStuDersOperations);
            panelMainMenu.Controls.Add(buttonCourseListing);
            panelMainMenu.Controls.Add(buttonStuListing);
            panelMainMenu.Controls.Add(buttonDelStu);
            panelMainMenu.Controls.Add(buttonAddStudent);
            panelMainMenu.Controls.Add(label2);
            panelMainMenu.Dock = DockStyle.Fill;
            panelMainMenu.Location = new Point(0, 0);
            panelMainMenu.Name = "panelMainMenu";
            panelMainMenu.Size = new Size(800, 450);
            panelMainMenu.TabIndex = 0;
            // 
            // panelStuDersOperations
            // 
            panelStuDersOperations.Controls.Add(listBox1);
            panelStuDersOperations.Controls.Add(buttonQuery);
            panelStuDersOperations.Controls.Add(buttonBack);
            panelStuDersOperations.Controls.Add(buttonDel);
            panelStuDersOperations.Controls.Add(buttonAdd);
            panelStuDersOperations.Controls.Add(textBoxDersKodu);
            panelStuDersOperations.Controls.Add(textBoxHarfOrt);
            panelStuDersOperations.Controls.Add(textBoxOrgNum);
            panelStuDersOperations.Controls.Add(label4);
            panelStuDersOperations.Controls.Add(label3);
            panelStuDersOperations.Controls.Add(label1);
            panelStuDersOperations.Location = new Point(3, 3);
            panelStuDersOperations.Name = "panelStuDersOperations";
            panelStuDersOperations.Size = new Size(800, 450);
            panelStuDersOperations.TabIndex = 15;
            // 
            // buttonQuery
            // 
            buttonQuery.Font = new Font("Segoe UI", 11F);
            buttonQuery.Location = new Point(12, 189);
            buttonQuery.Name = "buttonQuery";
            buttonQuery.Size = new Size(175, 51);
            buttonQuery.TabIndex = 9;
            buttonQuery.Text = "Sorgulama";
            buttonQuery.UseVisualStyleBackColor = true;
            buttonQuery.Click += buttonQuery_Click;
            // 
            // buttonBack
            // 
            buttonBack.Location = new Point(3, 6);
            buttonBack.Name = "buttonBack";
            buttonBack.Size = new Size(94, 29);
            buttonBack.TabIndex = 8;
            buttonBack.Text = "Geri";
            buttonBack.UseVisualStyleBackColor = true;
            buttonBack.Click += buttonBack_Click;
            // 
            // buttonDel
            // 
            buttonDel.BackColor = Color.FromArgb(255, 128, 128);
            buttonDel.Font = new Font("Segoe UI", 11F);
            buttonDel.Location = new Point(207, 189);
            buttonDel.Name = "buttonDel";
            buttonDel.Size = new Size(175, 54);
            buttonDel.TabIndex = 7;
            buttonDel.Text = "Sil";
            buttonDel.UseVisualStyleBackColor = false;
            buttonDel.Click += buttonDel_Click;
            // 
            // buttonAdd
            // 
            buttonAdd.BackColor = Color.FromArgb(128, 255, 128);
            buttonAdd.Font = new Font("Segoe UI", 11F);
            buttonAdd.Location = new Point(397, 189);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(175, 50);
            buttonAdd.TabIndex = 6;
            buttonAdd.Text = "Ekler";
            buttonAdd.UseVisualStyleBackColor = false;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // textBoxDersKodu
            // 
            textBoxDersKodu.Location = new Point(267, 92);
            textBoxDersKodu.Name = "textBoxDersKodu";
            textBoxDersKodu.Size = new Size(272, 27);
            textBoxDersKodu.TabIndex = 5;
            // 
            // textBoxHarfOrt
            // 
            textBoxHarfOrt.Location = new Point(267, 141);
            textBoxHarfOrt.Name = "textBoxHarfOrt";
            textBoxHarfOrt.Size = new Size(272, 27);
            textBoxHarfOrt.TabIndex = 4;
            // 
            // textBoxOrgNum
            // 
            textBoxOrgNum.Location = new Point(267, 43);
            textBoxOrgNum.Name = "textBoxOrgNum";
            textBoxOrgNum.Size = new Size(272, 27);
            textBoxOrgNum.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F);
            label4.Location = new Point(12, 133);
            label4.Name = "label4";
            label4.Size = new Size(191, 35);
            label4.TabIndex = 2;
            label4.Text = "Harf ortalaması:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(12, 83);
            label3.Name = "label3";
            label3.Size = new Size(150, 35);
            label3.TabIndex = 1;
            label3.Text = "Ders Kodu : ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(12, 43);
            label1.Name = "label1";
            label1.Size = new Size(229, 35);
            label1.TabIndex = 0;
            label1.Text = "Ögrenci Numarası :";
            // 
            // buttonCourseListing
            // 
            buttonCourseListing.Font = new Font("Segoe UI", 11F);
            buttonCourseListing.Location = new Point(61, 293);
            buttonCourseListing.Name = "buttonCourseListing";
            buttonCourseListing.Size = new Size(534, 64);
            buttonCourseListing.TabIndex = 14;
            buttonCourseListing.Text = "Bir öğrencinin aldığı tüm dersleri ders koduna göre sıralı listeleme";
            buttonCourseListing.UseVisualStyleBackColor = true;
            buttonCourseListing.Click += buttonCourseListing_Click;
            // 
            // buttonStuListing
            // 
            buttonStuListing.Font = new Font("Segoe UI", 11F);
            buttonStuListing.Location = new Point(61, 205);
            buttonStuListing.Name = "buttonStuListing";
            buttonStuListing.Size = new Size(534, 58);
            buttonStuListing.TabIndex = 12;
            buttonStuListing.Text = "Bir dersteki tüm öğrencileri numara sırasına göre sıralı listeleme";
            buttonStuListing.UseVisualStyleBackColor = true;
            buttonStuListing.Click += buttonStuListing_Click;
            // 
            // buttonDelStu
            // 
            buttonDelStu.Font = new Font("Segoe UI", 11F);
            buttonDelStu.Location = new Point(61, 130);
            buttonDelStu.Name = "buttonDelStu";
            buttonDelStu.Size = new Size(534, 56);
            buttonDelStu.TabIndex = 10;
            buttonDelStu.Text = "Bir öğrencinin bir dersini silme";
            buttonDelStu.UseVisualStyleBackColor = true;
            buttonDelStu.Click += buttonDelStu_Click;
            // 
            // buttonAddStudent
            // 
            buttonAddStudent.Font = new Font("Segoe UI", 11F);
            buttonAddStudent.Location = new Point(61, 47);
            buttonAddStudent.Name = "buttonAddStudent";
            buttonAddStudent.Size = new Size(534, 56);
            buttonAddStudent.TabIndex = 9;
            buttonAddStudent.Text = "Bir öğrenciye yeni bir ders ekleme";
            buttonAddStudent.UseVisualStyleBackColor = true;
            buttonAddStudent.Click += buttonAddStudent_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(131, 0);
            label2.Name = "label2";
            label2.Size = new Size(344, 35);
            label2.TabIndex = 8;
            label2.Text = "Öğrenci Ders Yönetim Sistemi";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(12, 266);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(465, 144);
            listBox1.TabIndex = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelMainMenu);
            Name = "Form1";
            Text = "Form1";
            panelMainMenu.ResumeLayout(false);
            panelMainMenu.PerformLayout();
            panelStuDersOperations.ResumeLayout(false);
            panelStuDersOperations.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMainMenu;
        private Panel panelStuDersOperations;
        private Button buttonCourseListing;
        private Button buttonStuListing;
        private Button buttonDelStu;
        private Button buttonAddStudent;
        private Label label2;
        private Label label1;
        private TextBox textBoxDersKodu;
        private TextBox textBoxHarfOrt;
        private TextBox textBoxOrgNum;
        private Label label4;
        private Label label3;
        private Button buttonAdd;
        private Button buttonBack;
        private Button buttonDel;
        private Button buttonQuery;
        private ListBox listBox1;
    }
}
