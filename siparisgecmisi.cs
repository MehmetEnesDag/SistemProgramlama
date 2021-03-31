using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 
namespace FooDino.Formlar.Admin_Panel
{
 //Datagridview'da sipariş geçmişleri görüntülenir.
 public partial class FormSiparisGecmisleri : Form
 {
 public FormSiparisGecmisleri()
 {
 InitializeComponent();
 }
 private void FormSiparisGecmisleri_Load(object sender, EventArgs e)
 {
 var db = new FooDinoDBEntities();
 dataGridView1.DataSource = db.Siparis.ToList();
 }
 }
}