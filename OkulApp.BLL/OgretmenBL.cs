using OkulApp.DAL;
using OkulApp.MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

/*namespace OkulApp.BLL
{
    public class OgretmenBL
    {
        public bool OgretmenKaydet(Ogretmen ogrt)
        {
            var hlp = new Helper();
            var p = new SqlParameter[] {
                new SqlParameter("@Ad",ogrt.Ad),
                new SqlParameter("@Soyad",ogrt.Soyad),
                new SqlParameter("@TcNo",ogrt.TcNo)
            };
            return hlp.ExecuteNonQuery("Insert into tblOgretmenler values(@Ad,@Soyad,@TcNo)", p) > 0;
        }
    }
}*/
namespace Okulapp.BLL
{
    public class OgretmenBL
    {
        public bool Ogretmenekle(Ogretmen ogrt)
        {
            var hlp = new Helper();
            var p = new SqlParameter[]
            {
                    new SqlParameter("@Ad",ogrt.Ad),
                    new SqlParameter("@Soyad",ogrt.Soyad),
                    new SqlParameter("@TcNO",ogrt.TcNo)
            };
            return hlp.ExecuteNonQuery("Insert into tblOgretmenler1 values(@Ad,@Soyad,@TC)", p) > 0;

        }

    }
}