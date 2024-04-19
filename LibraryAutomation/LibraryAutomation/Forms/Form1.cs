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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kullaniciadi = "Burak";
            string Sifre = "123";

            if (textBox1.Text == kullaniciadi && textBox2.Text == Sifre)
            {
                this.Hide();
                KütüphaneAnaSayfa anasayfa = new KütüphaneAnaSayfa();
                anasayfa.Show();
            }
            else if (textBox1.Text == kullaniciadi && textBox2.Text != Sifre)
            {
                MessageBox.Show("Şifreniz Yanlış Tekrar Deneyiniz");
            }
            else if (textBox1.Text != kullaniciadi && textBox2.Text == Sifre)
            {
                MessageBox.Show("Kullanıcı Adınızı Yanlış Girdiniz");
            }
            else
            {
                MessageBox.Show("Kullanıcı Adınız Ve Şifreniz Yanlış Veya Boş Girilmiş");
            }

        }
    }
}
