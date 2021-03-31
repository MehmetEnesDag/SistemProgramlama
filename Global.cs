using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FooDino.Formlar;
using static FooDino.Global;
namespace FooDino
{
 public partial class Form1 : Form
 {
 public Form1()
 {
 InitializeComponent();
 }
 public FooDinoDBEntities db = new FooDinoDBEntities();
 private void button_kayit_Click(object sender, EventArgs e) 
 {
 var kayitForm = new FormKayit();
 this.Hide();
 kayitForm.Show();
 }
 private void button_giris_Click(object sender, EventArgs e)
 {
 if (textBox_ad.Text == String.Empty ||
 textBox_sifre.Text == String.Empty ||
 textBox_soyad.Text == String.Empty)
 {
 MessageBox.Show("Lütfen tüm bilgileri doğru bir şekilde giriniz.");
 }
 else
 {
 var kayitliKullanici = db.Kullanici.FirstOrDefault(a => a.Ad ==
textBox_ad.Text &&
 a.Soyad ==
textBox_soyad.Text &&
a.Sifre ==
textBox_sifre.Text);
 if (kayitliKullanici == null)
 {
 MessageBox.Show("Kullanıcı bulunamadı. Bilgileri kontrol edin.");
 }
 else
 {
 SetGirisYapanKullanici(kayitliKullanici);
var formSiparis = new FormRestoranlar();
this.Hide();
Global.ReturnFormSiparis = formSiparis;
formSiparis.Show();
 }
 }
 }
 private void Form1_FormClosing(object sender, FormClosingEventArgs e)
 {
 /////
 }
 }
}