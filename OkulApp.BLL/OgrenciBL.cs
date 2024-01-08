using OkulApp.MODEL;
using System;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using OkulApp.DAL;
using System.Windows.Forms;
public class OgrenciBL
{
    Helper hlp = Helper.Instance;

    private static OgrenciBL instance;
    private OgrenciBL()
    {

    }
    public static OgrenciBL Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new OgrenciBL();
            }
            return instance;
        }
    }
    public bool OgrenciKaydet(Ogrenci ogr)
    {
        var p = new SqlParameter[]
        {
                 new SqlParameter("@Ad",ogr.Ad),
                    new SqlParameter("@Soyad",ogr.Soyad),
                    new SqlParameter("@Numara",ogr.Numara)
        };
        return hlp.ExecuteNonQuery("Insert into tblOgrenciler values(@Ad,@Soyad,@Numara)", p) > 0;


    }
    public Ogrenci OgrenciBul(string numara)
    {
        SqlParameter[] p = { new SqlParameter("@Numara", numara) };
        var dr = hlp.ExecuteReader("Select OgrenciId, Ad, Soyad, Numara from tblOgrenciler where Numara = @Numara", p);
        Ogrenci ogr = null;
        if (dr.Read())
        {
            ogr = new Ogrenci();
            ogr.Ad = dr["Ad"].ToString();
            ogr.Soyad = dr["Soyad"].ToString();
            ogr.Numara = dr["Numara"].ToString();
            ogr.Ogrenciid = Convert.ToInt32(dr["OgrenciId"].ToString());

        }
        dr.Close();
        return ogr;
    }
    public bool OgrenciSil(int id)
    {
        try
            {
                SqlParameter[] p = { new SqlParameter("@Id", id) };
                return hlp.ExecuteNonQuery("Delete from tblOgrenciler where Ogrenciid=@Id", p) > 0;
            }
            catch (SqlException sqlEx)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
    }
    public bool OgrenciGuncelle(Ogrenci ogr)
    {
        try
        {
            SqlParameter[] p = { new SqlParameter("@Ad",ogr.Ad ),
                new SqlParameter("@Soyad",ogr.Soyad),
                new SqlParameter("@Numara",ogr.Numara),
                new SqlParameter("@OgrenciId",ogr.Ogrenciid)
            };
            return hlp.ExecuteNonQuery("Update tblOgrenciler set Ad=@Ad, Soyad=@Soyad,Numara=@Numara where OgrenciId=@OgrenciId", p) > 0;
        
             }
        catch(SqlException sqlEx)
        {
         
                throw;
            }
            catch(Exception ex)
            {
                throw;
            }
            
        }
}
   
