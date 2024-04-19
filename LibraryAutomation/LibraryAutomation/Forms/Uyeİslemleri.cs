using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace LibraryAutomation
{
    public partial class Uyeİslemleri : Form
    {
        public Uyeİslemleri()
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

            List<Uye> üyeler = veritabani.Uyes.ToList();
            foreach (var item in üyeler )
            {
                dataGridView1.Rows.Add(item.id, item.Ad, item.Soyad, item.DogumTarihi, item.Cinsiyet, item.Telefon, item.Email, item.Adres);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            string SeciliUyeAdi = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Uye üyeler = veritabani.Uyes.Where(kayit => kayit.Ad == SeciliUyeAdi).FirstOrDefault();
            
            if (üyeler != null)
            {

                txtboxUyeAdi.Text = üyeler.Ad;
                txtboxUyeSoyadi.Text = üyeler.Soyad;
                datepickerDogumTarihi.Value = Convert.ToDateTime(üyeler.DogumTarihi);

                if (üyeler.Cinsiyet == "Erkek")
                {
                    radioErkek.Checked = true;
                }
                else
                {
                    radioKadın.Checked = true;
                }

                txtboxTelefon.Text = üyeler.Telefon;
                txtboxEmail.Text = üyeler.Email;
                txtboxAdres.Text = üyeler.Adres;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            dataGridView1.Rows.Clear();

            string UyeAdinaGoreAra = txtboxUyeAdiAra.Text;
            string UyeSoyadinaGoreAra = txtboxUyeSoyadiAra.Text;

            Uye üyeler = veritabani.Uyes.Where(kayit => kayit.Ad.Contains(UyeAdinaGoreAra) && kayit.Soyad.Contains(UyeSoyadinaGoreAra)).FirstOrDefault();

            dataGridView1.Rows.Add(üyeler.id,üyeler.Ad,üyeler.Soyad,üyeler.DogumTarihi,üyeler.Cinsiyet,üyeler.Telefon,üyeler.Email,üyeler.Adres);
        }

        private void btnUyeEkle_Click(object sender, EventArgs e)
        {

            dataGridView1.Rows.Clear();

            Uye üyeler = new Uye();
            
            üyeler.Ad = txtboxUyeAdi.Text;
            üyeler.Soyad = txtboxUyeSoyadi.Text;
            üyeler.DogumTarihi = datepickerDogumTarihi.Value;

            if (radioErkek.Checked)
            {
                üyeler.Cinsiyet = radioErkek.Text;
            }
            else
            {
                üyeler.Cinsiyet = radioKadın.Text;
            }
            üyeler.Telefon = txtboxTelefon.Text;
            üyeler.Email = txtboxEmail.Text;
            üyeler.Adres = txtboxAdres.Text;


            veritabani.Uyes.Add(üyeler);
            veritabani.SaveChanges();

            List<Uye> üyelerlist = veritabani.Uyes.ToList();
            foreach (var item in üyelerlist)
            {
                dataGridView1.Rows.Add(item.id, item.Ad, item.Soyad, item.DogumTarihi, item.Cinsiyet, item.Telefon, item.Email, item.Adres);
            }

            TextboxlariTemizle();

        }
        private void TextboxlariTemizle()
        {
            txtboxUyeAdi.Text = " ";
            txtboxUyeSoyadi.Text = " ";
            datepickerDogumTarihi.Value = DateTime.Now;
            radioErkek.Checked = false;
            radioKadın.Checked = false;
            txtboxTelefon.Text = " ";
            txtboxEmail.Text = " ";
            txtboxAdres.Text = " ";

        }

        private void btnUyeSil_Click(object sender, EventArgs e)
        {
            
            string SeciliUyeAdi = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Uye üyeler = veritabani.Uyes.Where(kayit => kayit.Ad == SeciliUyeAdi).FirstOrDefault();

            if (üyeler!=null)
            {
                veritabani.Uyes.Remove(üyeler);
                veritabani.SaveChanges();
            }

            dataGridView1.Rows.Clear();

            List<Uye> üyelerlist = veritabani.Uyes.ToList();
            foreach (Uye item in üyelerlist)
            {
                dataGridView1.Rows.Add(item.id, item.Ad, item.Soyad, item.DogumTarihi, item.Cinsiyet, item.Telefon, item.Email, item.Adres);
            }

            TextboxlariTemizle();

        }

        private void btnUyeGuncelle_Click(object sender, EventArgs e)
        {

            string SeciliUyeyiGuncelle = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Uye üyeler = veritabani.Uyes.Where(kayit => kayit.Ad == SeciliUyeyiGuncelle).FirstOrDefault();

            üyeler.Ad = txtboxUyeAdi.Text;
            üyeler.Soyad = txtboxUyeSoyadi.Text;
            üyeler.DogumTarihi = datepickerDogumTarihi.Value;
            
            if (radioErkek.Checked)
            {
                üyeler.Cinsiyet = radioErkek.Text;
            }
            else
            {
                üyeler.Cinsiyet = radioKadın.Text;
            }

            üyeler.Telefon = txtboxTelefon.Text;
            üyeler.Email = txtboxEmail.Text;
            üyeler.Adres = txtboxAdres.Text;

            veritabani.SaveChanges();

            dataGridView1.Rows.Clear();

            List<Uye> üyelerilistele = veritabani.Uyes.ToList();
            foreach (var item in üyelerilistele)
            {
                dataGridView1.Rows.Add(item.id, item.Ad, item.Soyad, item.DogumTarihi, item.Cinsiyet, item.Telefon, item.Email, item.Adres);
            }

            TextboxlariTemizle();
        }
    }
}
