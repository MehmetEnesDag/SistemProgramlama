using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Global sınıfını ekler.
using static FooDino.Global;
namespace FooDino.Formlar.Admin_Panel
{
 public partial class FormRestoranDuzenle : Form
 {
 public FormRestoranDuzenle()
 { 
 InitializeComponent();
 }
 FooDinoDBEntities db = new FooDinoDBEntities();
 private void FormRestoranDuzenle_Load(object sender, EventArgs e)
 {
 var resList = db.Restorant.ToList();
 dataGridView1.DataSource = resList;
 }
 private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
 {
 //Id hücresine iki kere tıklanıldığında , Id'ye göre Restorantı bulur ve
SecilenRestorant
 // değişkenine atar.
 var id = Convert.ToInt32(dataGridView1.CurrentCell.Value.ToString());
 SetSecilenRestorant(db.Restorant.FirstOrDefault(r=>r.Id == id));
 if (GetSecilenRestorant() == null)
 {
 MessageBox.Show("Hata.");
 }
 else
 {
 textBox_ResAd.Text = GetSecilenRestorant().Ad;
 textBox_ResAdres.Text = GetSecilenRestorant().Adres;
 textBox_ResPuan.Text = GetSecilenRestorant().Puan;
 }
 }
 private void button_kaydet_Click(object sender, EventArgs e)
 {
 //Girilen bilgiler eksik veya boş işe bir hata mesajı ile karşılaşılır.
 if (textBox_ResAdres.Text == String.Empty
 || textBox_ResAd.Text == String.Empty
 || textBox_ResPuan.Text == String.Empty)
 {
 MessageBox.Show("Eksik bilgi girdiniz.");
 }
 else
 {
 //Eğer her bilgi eksiksiz girildiyse, Restorant ID'sine göre
restorantı bulur ve düzenler.
 var id = GetSecilenRestorant().Id;
 var res = db.Restorant.FirstOrDefault(r => r.Id == id);
 res.Ad = textBox_ResAd.Text;
 res.Adres = textBox_ResAdres.Text;
 res.Puan = textBox_ResPuan.Text;
 db.SaveChanges();
 MessageBox.Show("Başarılı.");
 textBox_ResAdres.Text = String.Empty;
 textBox_ResAd.Text = String.Empty;
 textBox_ResPuan.Text = String.Empty;
 var resList = db.Restorant.ToList();
 dataGridView1.DataSource = resList;
 }
 }
 private void button_ekle_Click(object sender, EventArgs e)
 { 
 // res adında bir obje oluştu. Bu objenin Ad,Adres ve Puan değişkenlerini
textBoxlardan alıyoruz.
 var res = new Restorant();
 res.Ad = textBox_ResAd.Text;
 res.Adres = textBox_ResAdres.Text;
 res.Puan = textBox_ResPuan.Text;
 //Database'e ekliyoruz.
 db.Restorant.Add(res);
 db.SaveChanges();
 MessageBox.Show("Başarılı.");
 textBox_ResAdres.Text = String.Empty;
 textBox_ResAd.Text = String.Empty;
 textBox_ResPuan.Text = String.Empty;
 var resList = db.Restorant.ToList();
 dataGridView1.DataSource = resList;
 }
 private void button_sil_Click(object sender, EventArgs e)
 {
 //GetSecilenRestorant kısmındaki restorantı remove ediyoruz.
 db.Restorant.Remove(GetSecilenRestorant());
 db.SaveChanges();
 MessageBox.Show("Başarılı.");
 textBox_ResAdres.Text = String.Empty;
 textBox_ResAd.Text = String.Empty;
 textBox_ResPuan.Text = String.Empty;
 var resList = db.Restorant.ToList();
 dataGridView1.DataSource = resList;
 }
 }
} 