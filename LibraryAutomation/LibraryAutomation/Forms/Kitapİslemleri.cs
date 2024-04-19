using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryAutomation
{
    public partial class Kitapİslemleri : Form
    {
        public Kitapİslemleri()
        {
            InitializeComponent();
        }
        LibraryDatabaseEntities veritabani = new LibraryDatabaseEntities();

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            KütüphaneAnaSayfa anasayfa = new KütüphaneAnaSayfa();
            anasayfa.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            List<Kitap> kitaplar = veritabani.Kitaps.ToList();
            foreach (var item in kitaplar)
            {
                dataGridView1.Rows.Add(item.id, item.KitapAdi, item.Yazar, item.Tur, item.SayfaSayisi, item.BasimYili, item.YayinEvi, item.Adet);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string SeciliKitapAdi = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Kitap ktp = veritabani.Kitaps.Where(kayit => kayit.KitapAdi == SeciliKitapAdi).FirstOrDefault();

            if (ktp != null)
            {

                txtboxKitapAdi.Text = ktp.KitapAdi;
                txtboxYazarAdi.Text = ktp.Yazar;
                cmbboxTur.Text = ktp.Tur;
                txtboxSayfaSayisi.Text = ktp.SayfaSayisi.ToString();
                txtboxBasimYili.Text = ktp.BasimYili.ToString();
                txtboxYayinEvi.Text = ktp.YayinEvi;
                txtboxAdet.Text = ktp.Adet.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            string KitapAdinaGoreGetir = txtboxKitapAra.Text;

            List<Kitap> ktpliste = veritabani.Kitaps.Where(kayit => kayit.KitapAdi.Contains(KitapAdinaGoreGetir)).ToList();

            foreach (var item in ktpliste)
            {
                dataGridView1.Rows.Add(item.id, item.KitapAdi, item.Yazar, item.Tur, item.SayfaSayisi, item.BasimYili, item.YayinEvi, item.Adet);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            Kitap ktp = new Kitap();

            ktp.KitapAdi = txtboxKitapAdi.Text;
            ktp.Yazar = txtboxYazarAdi.Text;
            ktp.Tur = cmbboxTur.Text;
            ktp.SayfaSayisi = Convert.ToInt32(txtboxSayfaSayisi.Text);
            ktp.BasimYili = Convert.ToInt32(txtboxBasimYili.Text);
            ktp.YayinEvi = txtboxYayinEvi.Text;
            ktp.Adet = Convert.ToInt32(txtboxAdet.Text);

            veritabani.Kitaps.Add(ktp);
            veritabani.SaveChanges();


            List<Kitap> kitaplar = veritabani.Kitaps.ToList();
            foreach (var item in kitaplar)
            {
                dataGridView1.Rows.Add(item.id, item.KitapAdi, item.Yazar, item.Tur, item.SayfaSayisi, item.BasimYili, item.YayinEvi, item.Adet);
            }

            TextBoxlariTemizle();
        }
        private void TextBoxlariTemizle()
        {
            txtboxKitapAdi.Text = "";
            txtboxYazarAdi.Text = "";
            cmbboxTur.Text = "";
            txtboxSayfaSayisi.Text = "";
            txtboxBasimYili.Text = "";
            txtboxYayinEvi.Text = "";
            txtboxAdet.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string SeciliKitabıSil = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Kitap ktp = veritabani.Kitaps.Where(kayit => kayit.KitapAdi == SeciliKitabıSil).FirstOrDefault();

            if (ktp != null)
            {
                veritabani.Kitaps.Remove(ktp);
                veritabani.SaveChanges();
            }

            dataGridView1.Rows.Clear();

            List<Kitap> kitaplar = veritabani.Kitaps.ToList();
            foreach (var item in kitaplar)
            {
                dataGridView1.Rows.Add(item.id, item.KitapAdi, item.Yazar, item.Tur, item.SayfaSayisi, item.BasimYili, item.YayinEvi, item.Adet);
            }

            TextBoxlariTemizle();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string SeciliKitabıGuncelle = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Kitap ktp = veritabani.Kitaps.Where(kayit => kayit.KitapAdi == SeciliKitabıGuncelle).FirstOrDefault();

            ktp.KitapAdi = txtboxKitapAdi.Text;
            ktp.Yazar = txtboxYazarAdi.Text;
            ktp.Tur = cmbboxTur.Text;
            ktp.SayfaSayisi = Convert.ToInt32(txtboxSayfaSayisi.Text);
            ktp.BasimYili = Convert.ToInt32(txtboxBasimYili.Text);
            ktp.YayinEvi = txtboxYayinEvi.Text;
            ktp.Adet = Convert.ToInt32(txtboxAdet.Text);

            veritabani.SaveChanges();

            dataGridView1.Rows.Clear();

            List<Kitap> kitaplar = veritabani.Kitaps.ToList();
            foreach (var item in kitaplar)
            {
                dataGridView1.Rows.Add(item.id, item.KitapAdi, item.Yazar, item.Tur, item.SayfaSayisi, item.BasimYili, item.YayinEvi, item.Adet);
            }

            TextBoxlariTemizle();
        }
    }
}
