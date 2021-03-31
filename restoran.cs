using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FooDino.Formlar.Admin_Panel;
using FooDino.User_Controls;
using static FooDino.Global;
namespace FooDino.Formlar
{
 public partial class FormRestoranlar : Form
 {
 public FormRestoranlar()
 {
 InitializeComponent();
 }
 private void FormSiparis_Load(object sender, EventArgs e)
 {
 //Kullanılan groupBox1 bizim admin panelimizdir. Kullanıcı eğer "Deniz
Kara" olarak giriş
 //yaparsa groupBox visible hale gelir.Admin paneline erişilir.
 label_ad.Text = GetGirisYapanKullanici().Ad;
 groupBox1.Visible = false;
 var context = new FooDinoDBEntities();
 var listRestorant = context.Restorant.ToList();
 foreach (var restorant in listRestorant)
 {
 new PanelIslemleri().PaneleRestorantEkle(flowLayoutPanel1, restorant);
 //Global.PaneleRestorantEkle(flowLayoutPanel1, restorant);
 }
 if (GetGirisYapanKullanici().Ad == "Deniz" &&
 GetGirisYapanKullanici().Soyad == "Kara")
 {
 groupBox1.Visible = true;
 }
 }
 private void label2_Click(object sender, EventArgs e)
 {
 var formProfil = new FormProfil();
 formProfil.Show();
 }
 private void label3_Click(object sender, EventArgs e)
 {
 SetGirisYapanKullanici(null);
 var mainForm = new Form1();
 mainForm.Show();
 this.Close();
 }
 private void button_restorantIslemleri_Click(object sender, EventArgs e)
 {
 var formRestoranDuzenle = new FormRestoranDuzenle();
 formRestoranDuzenle.Show();
 }
 private void button_urunIslemleri_Click(object sender, EventArgs e)
 {
 var formUrunDuzenle = new FormUrunDuzenle();
 formUrunDuzenle.Show();
 }
 private void button_siparisGecmisleri_Click(object sender, EventArgs e)
 {

 var formSiparisGecmisleri = new FormSiparisGecmisleri();
 formSiparisGecmisleri.Show();

 }
 }
} 