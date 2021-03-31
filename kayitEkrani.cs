using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace FooDino.Formlar
{
 public partial class FormKayit : Form
 {
 public FormKayit()
 {
 InitializeComponent();
 }
 public FooDinoDBEntities DbEntities = new FooDinoDBEntities();
 private void FormKayit_Load(object sender, EventArgs e)
 {
 }
 private void button_kayit_kayitOl_Click(object sender, EventArgs e)
 {
 if (textBox_kayit_ad.Text == String.Empty
 || textBox_kayit_adres.Text == String.Empty
 || textBox_kayit_mail.Text == String.Empty
 || textBox_kayit_sifre.Text == String.Empty
 || textBox_kayit_soyad.Text == String.Empty
 || textBox_kayit_telefon.Text == String.Empty)
 {
 MessageBox.Show("Lütfen tüm bilgileri doğru bir şekilde giriniz.");
 }
 else
 {
 var kullanici = new Kullanici 
 {
 Ad = textBox_kayit_ad.Text,
Soyad = textBox_kayit_soyad.Text,
Adres = textBox_kayit_adres.Text,
Mail = textBox_kayit_mail.Text,
Telefon = textBox_kayit_telefon.Text,
Sifre = textBox_kayit_sifre.Text
 };
 DbEntities.Kullanici.Add(kullanici);
 DbEntities.SaveChanges();

 this.Close();
 }
 }
 private void FormKayit_FormClosed(object sender, FormClosedEventArgs e)
 {
 var mainForm = new Form1();
 mainForm.Show();
 }
 }
}
