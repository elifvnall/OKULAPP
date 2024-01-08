using OkulApp.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OkulAppSube2BIL
{
    public partial class frmOrgBul : Form
    {
        frmOgrKayit frm;
        public frmOrgBul(frmOgrKayit frm)
        {
            InitializeComponent();
            this .frm = frm;    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OgrenciBL obl = new OgrenciBL();
                Ogrenci ogr = obl.OgrenciBul(textBox1.Text.Trim());

                if (ogr != null)
                {
                    frm.txtAd.Text = ogr.Ad;
                    frm.txtSoyad.Text = ogr.Soyad;
                    frm.txtNumara.Text = ogr.Numara;
                    frm.Ogrenciid = ogr.Ogrenciid;
                    frm.button2.Enabled = true; //silme butonu
                    frm.button3.Enabled = true; //güncelleme butonu
                    this.Close();
                   // this.Hide(); //Öğrenci bulunduğunda bul formunun kapanması

                }
                else
                {
                    MessageBox.Show("Öğrenci Bulunamadı!!");
                    frm.button2.Enabled = false;
                    frm.button3.Enabled = false;
                    
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("Veritabanı Hatası: ");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Bilinmeyen Hata: ");

            }

        }
    }
    }



/*try
{
    // Potansiyel olarak hata verebilecek kod bloğu
    // Örneğin, veritabanına erişimle ilgili bir işlem
}
catch (SqlException sqlEx)
{
    // SqlException türündeki hataları ele almak için bu blok
    // Bu blok, veritabanı işlemleri sırasında oluşan özel hataları ele alır
    // ve uygun bir şekilde işler.
    Console.WriteLine("Veritabanı hatası oluştu: " + sqlEx.Message);
}
catch (Exception ex)
{
    // Genel bir hata durumu için bu blok
    // SqlException dışındaki diğer hataları ele alır
    Console.WriteLine("Bir hata oluştu: " + ex.Message);
}
finally
{
    // Her durumda çalıştırılacak kod bloğu
    // Örneğin, kaynakları temizleme veya kapatma işlemleri
}*/