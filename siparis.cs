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
 public partial class FormSiparisler : Form
 {
 public FormSiparisler() 
 {
 InitializeComponent();
 }
 private void FormSiparisler_Load(object sender, EventArgs e)
 {
 label_restorantAd.Text = GetSecilenRestorant().Ad;
 var db = new FooDinoDBEntities();
 var id = GetSecilenRestorant().Id;
 //Seçilen restorantın ürünlerini listeliyoruz.
 var listUrun = db.Urun.Where(u => u.Restorant_Id == id);
 foreach (var urun in listUrun)
 {
 new PanelIslemleri().PaneleUrunEkle(flowLayoutPanel1, urun);
 }
 textBox1.Text = GetGirisYapanKullanici().Adres;
 }
 private void label_profilim_Click(object sender, EventArgs e)
 {
 var formProfil = new FormProfil();
 formProfil.Show();
 }
 private void label_anasayfa_Click(object sender, EventArgs e)
 {
 SetSecilenRestorant(null);
 var formRes = new FormRestoranlar();
 formRes.Show();
 this.Close();
 }
 private void label_cikis_Click(object sender, EventArgs e)
 {
 //Çıkış yaparken tüm değerleri null olarak atıyoruz.
 SetGirisYapanKullanici(null);
 SetSecilenRestorant(null);
 var mainForm = new Form1();
 mainForm.Show();
 this.Close();
 }
 private void FormSiparisler_FormClosing(object sender, FormClosingEventArgs e)
 {
 SepetFiyat = 0;
 }
 private void button_siparisTamamla_Click(object sender, EventArgs e)
 {
 //Sipariş tamamlanınca sipariş bilgilerini database'e kaydediyoruz.
 var siparis = new Siparis();
 siparis.Kullanici_Id = GetGirisYapanKullanici().Id;
 siparis.Fiyat = SepetFiyat;
 siparis.Tarih = DateTime.Now;
 foreach (var urun in SepetUrunler)
 {
 siparis.Urun_Id = urun.Id;
 using (var db = new FooDinoDBEntities())
 {
 db.Siparis.Add(siparis);
db.SaveChanges(); 
 }
 }
 MessageBox.Show("Siparişiniz alındı.");
 var formRestoranlar = new FormRestoranlar();
 formRestoranlar.Show();
 this.Close();
 }
 }
} 