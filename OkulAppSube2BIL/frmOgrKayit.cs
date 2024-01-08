using OkulApp.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OkulApp.BLL;
using OkulApp.DAL;


namespace OkulAppSube2BIL
{
    public partial class frmOgrKayit : Form
    {
        public int Ogrenciid { get; set; }
        public frmOgrKayit(frmOgrKayit frmOgrKayit)
        {
            InitializeComponent();
        }

        //Dispose
        //Garbage Collector
        private void btnKaydet_Click(object sender, EventArgs e)
        //new Ogrenci { Ad = txtAd.Text.Trim(), Soyad = txtSoyad.Text.Trim(), Numara = txtNumara.Text.Trim() })
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    (item as TextBox).Clear();
                }
            } // TEXTBOXLARIN TEMZİLENMESİ İÇİN KOD BLOg
            try
            {
                //var ogrenci = new Ogrenci();
                //ogrenci.Ad = txtAd.Text.Trim();
                //ogrenci.Soyad = txtSoyad.Text.Trim();
                //ogrenci.Numara = txtNumara.Text.Trim();

                var obl = new OgrenciBL();
                bool sonuc = obl.OgrenciKaydet(new Ogrenci { Ad = txtAd.Text.Trim(), Soyad = txtSoyad.Text.Trim(), Numara = txtNumara.Text.Trim() });
                MessageBox.Show(sonuc ? "Ekleme Başarılı" : "Ekleme Başarısız!!");

            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 2627:
                        MessageBox.Show("Bu numara daha önce kaydedilmiş");
                        break;
                    default:
                        MessageBox.Show("Veritabanı Hatası!");
                        break;
                }
            }
            catch (Exception ex)
            {
                throw;
                MessageBox.Show("Bilinmeyen Hata!!");
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmOrgBul(this);
                frm.Show();
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("Veritabanı Hatası: " + sqlEx.Message);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Bilinmeyen Hata: " + ex.Message);

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var obl = new OgrenciBL();
                MessageBox.Show(obl.OgrenciSil(Ogrenciid) ? "Silme Başarılı" : "Silme Başarısız!");

                txtAd.Text = "";
                txtSoyad.Text = "";
                txtNumara.Text = "";
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("Veritabanı Hatası: " + sqlEx.Message);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Bilinmeyen Hata: " + ex.Message);

            }
        }

        /*
        class Transfer : ITransferIslemleri
        {
            public int Eft(string gondereniban, string aliciiban, double tutar)
            {
                throw new NotImplementedException();
            }

            public int Havale(string gondereniban, string aliciiban, double tutar)
            {
                throw new NotImplementedException();
            }
        }

/*
        interface ITransferIslemleri
        {
            int Eft(string gondereniban, string aliciiban, double tutar);
            int Havale(string gondereniban, string aliciiban, double tutar);
        }*/

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var obl = new OgrenciBL();
                MessageBox.Show(obl.OgrenciGuncelle(new Ogrenci { Ad = txtAd.Text.Trim(), Soyad = txtSoyad.Text.Trim(), Numara = txtNumara.Text.Trim(), Ogrenciid = Ogrenciid })
                ? "Güncelleme Başarılı" : "Güncelleme Başarısız!");

                txtAd.Text = "";
                txtSoyad.Text = "";
                txtNumara.Text = "";
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("Veritabanı Hatası: " );

            }
            catch (Exception ex)
            {
                Console.WriteLine("Bilinmeyen Hata: " );

            }
        }
    }
}


//n Katmanlı Mimari

//Öğrenci bulunma durumuna göre Sil ve Güncelle Butonları Aktifliği
//Textbox'ların text'lerinin temizlenmesi
//Öğrenci bulunduğunda bul formunun kapanması
//Try-Catch'ler Katmanlar arası exception yönetimi
//Dispose Pattern - IDisposeble Interface
//Singleton Design Pattern





//Singleton Design Pattern :bir uygulama içinde tek bir nesne örneğine ihtiyaç duyulduğu durumlarda kullanışlıdır. 
//Constructor private olmalı. Bu yapılan işlem new ile nesne oluşturulmasını engeller.
//Class ile aynı türde static bir member oluşturulur.
//Örneğin;
class SingletonExample
{
    private static SingletonExample instance;
}
//Static member’a ulaşmak için static bir metot oluşturulmalıdır.
//Örneğin;
//public static Singleton getInstance() { … return instance; }

//Instance’ları new ile yaratmıyoruz. Bunun yerine getInstance metodunu kullanıyoruz. Bu metot ise bize her defasında aynı instance’ı veriyor.

public sealed class Singleton
{
   
    private static Singleton instance; // Singleton sınıfının tek örneğini tutan bir static değişken.
    private static readonly object lockObject = new object(); //Çoklu iş parçacığı ortamlarında güvenliği sağlamak için kullanılan bir kilit nesnesi.

    // Private kurucu metod, sınıfın dışından doğrudan erişilemez.
    private Singleton() //Sınıfın dışından doğrudan erişilemeyen bir özel kurucu metod.
    {
        // Singleton sınıfının oluşturulmasıyla ilgili gerekli işlemler burada yapılabilir.
    }

    // Singleton örneğini döndüren metot
    public static Singleton Instance //Singleton örneğini döndüren bir özellik (property). Bu özellik, ihtiyaç duyulduğunda Singleton örneğini oluşturur.
    {
        get
        {
            // Eğer önce hiç oluşturulmamışsa veya null ise, yeni bir örnek oluştur.
            if (instance == null)
            {
                lock (lockObject) // Çoklu iş parçacığı ortamlarında güvenliği sağlamak için kilit kullanılır.
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                }
            }
            return instance;
        }
    }

    // Singleton sınıfının diğer metotları buraya eklenir.
    public void SomeMethod()
    {
        // Singleton sınıfının işlemleri burada yapılır.
    }
}