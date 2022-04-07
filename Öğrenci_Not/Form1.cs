using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using FacadeLayerr;
using BusinessLogicLayer;

namespace Öğrenci_Not
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void OgrenciListesi()
        {
            List<EntityOgrencı> ogrlist = BLLOGRENCI.LISTELE();
            dataGridView1.DataSource = ogrlist;
            this.Text = "Öğrenci Listesi";
        }
        void KulupListesi()
        {
            List<EntityKulup> KulupList = BLLKULUP.LISTELE();
            CmbKulup.DisplayMember = "KULUPAD";
            CmbKulup.ValueMember = "ID";
            CmbKulup.DataSource = KulupList;
            dataGridView1.DataSource = KulupList;
            this.Text = "Kulüp Listesi";
        }
        void NotListesi()
        {
            List<EntityNotlar> EntNot = BLLNOTLAR.LISTELE();
            dataGridView1.DataSource = EntNot;
            this.Text = "Not Listesi";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            OgrenciListesi();
            KulupListesi();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            EntityOgrencı ent = new EntityOgrencı();
            ent.AD = TxtAd.Text;
            ent.SOYAD = TxtSoyad.Text;
            ent.FOTOGRAF = TxtFotograf.Text;
            ent.KULUPID = Convert.ToInt16(CmbKulup.SelectedValue);
            BLLOGRENCI.EKLE(ent);
            MessageBox.Show("Öğrenci Kaydı Yapıldı!!","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            OgrenciListesi();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.Text == "Öğrenci Listesi")
            {
                int secilen = dataGridView1.SelectedCells[0].RowIndex;
                Txtİd.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
                TxtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
                TxtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
                TxtFotograf.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            }
            if(this.Text == "Not Listesi")
            {
                int secilen = dataGridView1.SelectedCells[0].RowIndex;
                TxtOgrid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
                TxtAd.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
                TxtSoyad.Text = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
                TxtS1.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
                TxtS2.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
                TxtS3.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
                TxtProje.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
                TxtOrt.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
                TxtDurum.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            }
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            OgrenciListesi();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            EntityOgrencı ent = new EntityOgrencı();
            ent.AD = TxtAd.Text;
            ent.SOYAD = TxtSoyad.Text;
            ent.FOTOGRAF = TxtFotograf.Text;
            ent.KULUPID = Convert.ToInt16(CmbKulup.SelectedValue);
            ent.ID = Convert.ToInt16(Txtİd.Text);
            BLLOGRENCI.GUNCELLE(ent);
            MessageBox.Show("Öğrenci Bilgileri Güncellendi.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            OgrenciListesi();
        }

        private void BtnNotListele_Click(object sender, EventArgs e)
        {
            NotListesi();
        }

        private void BtnNotGuncelle_Click(object sender, EventArgs e)
        {
            EntityNotlar ent = new EntityNotlar();
            ent.OGRENCIID = Convert.ToInt16(TxtOgrid.Text);
            ent.SINAV1 = Convert.ToInt16(TxtS1.Text);
            ent.SINAV2 = Convert.ToInt16(TxtS2.Text);
            ent.SINAV3 = Convert.ToInt16(TxtS3.Text);
            ent.PROJE = Convert.ToInt16(TxtProje.Text);
            ent.ORTALAMA = Convert.ToInt16(TxtOrt.Text);
            ent.DURUM = TxtDurum.Text;
            BLLNOTLAR.GUNCELLE(ent);
            MessageBox.Show("Notlar Güncellendi.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            NotListesi();
        }

        private void Btn_Hesapla_Click(object sender, EventArgs e)
        {
            int s1, s2, s3, proje;
            double ort;
            string durum;

            s1 = Convert.ToInt16(TxtS1.Text);
            s2 = Convert.ToInt16(TxtS2.Text);
            s3 = Convert.ToInt16(TxtS3.Text);
            proje = Convert.ToInt16(TxtProje.Text);
            ort = (s1 + s2 + s3 + proje) / 4;
            TxtOrt.Text = ort.ToString();
            if(ort >=50)
            {
                durum = "True";
            }
            else 
            {
                durum = "False";
            }
            TxtDurum.Text = durum;
        }

        private void BtnKulupListele_Click(object sender, EventArgs e)
        {
            KulupListesi();
        }

        private void BtnKulupKaydet_Click(object sender, EventArgs e)
        {
            EntityKulup ent = new EntityKulup();
            ent.KULUPAD = TxtKulupAd.Text;
            BLLKULUP.EKLE(ent);
            KulupListesi();
        }

        private void BtnKulupSil_Click(object sender, EventArgs e)
        {
            EntityKulup ent = new EntityKulup();
            ent.ID = Convert.ToInt16(TxtKulupİd.Text);
            BLLKULUP.SIL(ent.ID);
            KulupListesi();
        }

        private void BtnKulupGuncelle_Click(object sender, EventArgs e)
        {
            EntityKulup ent = new EntityKulup();
            ent.KULUPAD = TxtKulupAd.Text;
            ent.ID = Convert.ToInt16(TxtKulupİd.Text);
            BLLKULUP.GUNCELLE(ent);
            KulupListesi();
        }
    }
}
