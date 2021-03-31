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
//Global sınıfını ekler
using static FooDino.Global; 
namespace FooDino.User_Controls
{
 public partial class RestorantItem : UserControl
 {
 public RestorantItem()
 {
 InitializeComponent();
 }
 private void RestorantItem_Click(object sender, EventArgs e)
 {
 using (var db = new FooDinoDBEntities())
 {
 //UserControlde yazan ada göre Restorantı buluyor.
 var res = db.Restorant.FirstOrDefault(r => r.Ad ==
this.label_RestorantAd.Text);
 //Global.cs 'de SecilenRestorant değişkenine değer atıyoruz.
 SetSecilenRestorant(res);
 }
 //TopLevelControl ile formun kontrolüne erişiyoruz ve formu kapatıyoruz.
 ((Form)this.TopLevelControl)?.Close();
 var formSiparisler = new FormSiparisler();
 formSiparisler.Show();
 }
 }
}
