using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FooDino.Global;
namespace FooDino.Formlar
{
 public partial class FormProfil : Form
 {
 public FormProfil()
 {
 InitializeComponent();
 }
 private void FormProfil_Load(object sender, EventArgs e)
 {
 textBox_ad.Text = GetGirisYapanKullanici().Ad;
 textBox_soyad.Text = GetGirisYapanKullanici().Soyad;
 textBox_adres.Text = GetGirisYapanKullanici().Adres;
 textBox_mail.Text = GetGirisYapanKullanici().Mail;
 textBox_telefon.Text = GetGirisYapanKullanici().Telefon;
 textBox_sifre.Text = GetGirisYapanKullanici().Sifre;
 }
 private void button_kayit_kayitOl_Click(object sender, EventArgs e)
 {
 using (var db = new FooDinoDBEntities())
 {
 var ad = GetGirisYapanKullanici().Ad;
 var soyad = GetGirisYapanKullanici().Soyad;
 var sifre = GetGirisYapanKullanici().Sifre;
 var kayitliKullanici = db.Kullanici.FirstOrDefault(a => a.Ad == ad &&
 a.Soyad ==
soyad &&
a.Sifre ==
sifre);
 if (kayitliKullanici == null)
 MessageBox.Show("Hata.");
 else
 {
 kayitliKullanici.Adres = textBox_adres.Text;
kayitliKullanici.Mail = textBox_mail.Text;
kayitliKullanici.Sifre = textBox_sifre.Text;
kayitliKullanici.Telefon = textBox_telefon.Text;
 db.SaveChanges();
 }
 this.Close();
 }
 } 
 }
}