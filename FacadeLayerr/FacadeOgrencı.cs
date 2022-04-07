using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using EntityLayer;

namespace FacadeLayerr
{
    public class FacadeOgrencı
    {
        public static int EKLE(EntityOgrencı deger)
        {
            SqlCommand komut = new SqlCommand("OGRENCIEKLE", SQLBAGLANTISI.baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("AD", deger.AD);
            komut.Parameters.AddWithValue("SOYAD", deger.SOYAD);
            komut.Parameters.AddWithValue("@FOTOGRAF", deger.FOTOGRAF);
            komut.Parameters.AddWithValue("KULUPID", deger.KULUPID);
            return komut.ExecuteNonQuery();
        }
        public static bool SİL(int deger)
        {
            SqlCommand komut = new SqlCommand("OGRENCISIL", SQLBAGLANTISI.baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("ID", deger);
            return komut.ExecuteNonQuery() > 0;
        }
        public static bool GUNCELLE(EntityOgrencı deger)
        {
            SqlCommand komut = new SqlCommand("OGRENCIGUNCELLE", SQLBAGLANTISI.baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("AD", deger.AD);
            komut.Parameters.AddWithValue("SOYAD", deger.SOYAD);
            komut.Parameters.AddWithValue("FOTOGRAF", deger.FOTOGRAF);
            komut.Parameters.AddWithValue("KULUPID", deger.KULUPID);
            komut.Parameters.AddWithValue("ID", deger.ID);
            return komut.ExecuteNonQuery() > 0;
        }
        public static List<EntityOgrencı> OgrencıListesi()
        {
            List<EntityOgrencı> degerler = new List<EntityOgrencı>();
            SqlCommand komut = new SqlCommand("OGRENCILISTESI", SQLBAGLANTISI.baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                EntityOgrencı ent = new EntityOgrencı();
                ent.AD = dr["AD"].ToString();
                ent.SOYAD = dr["SOYAD"].ToString();
                ent.FOTOGRAF = dr["FOTOGRAF"].ToString();
                ent.KULUPID = Convert.ToInt16(dr["KULUPID"]);
                ent.ID = Convert.ToInt16(dr["ID"]);
                degerler.Add(ent);
            }
            dr.Close();
            return degerler;
        }        
}
    }

